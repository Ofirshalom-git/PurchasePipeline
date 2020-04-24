using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Reflection;

namespace UnitTestBase
{
    public class DynamicObjectBase : DynamicObject
    {
        private readonly Type _type;
        private readonly Object _instance;

        private readonly Dictionary<string, MethodInfo> _methods =
            new Dictionary<string, MethodInfo>();

        public DynamicObjectBase(Object instance)
        {
            _instance = instance;
            _type = instance.GetType();
        }

        public DynamicObjectBase(Type type)
        {
            _instance = null;
            _type = type;
        }

        public override bool TryInvokeMember
        (InvokeMemberBinder binder, object[] args, out object result)
        {
            if (!_methods.ContainsKey(binder.Name))
            {
                var methodInfo = _type.GetMethod(binder.Name,
                BindingFlags.NonPublic | BindingFlags.Static |
                BindingFlags.Instance | BindingFlags.Public);
                _methods.Add(binder.Name, methodInfo);
            }

            var method = _methods[binder.Name];
            result = method.Invoke(method.IsStatic ? null : _instance, args);

            return true;
        }

        //use in tests class
        private readonly dynamic _range;

        public RangeFixture()
        {
            _range = new DynamicObjectBase(typeof(Range<int>));
        }

        [Test,
        Description("Tests two ranges that don't overlap.")]
        public void DynamicOverlapTest([Random(0, 1000, 5)] int firstStart,
                                [Random(1001, 2000, 5)] int firstEnd,
                                [Random(2001, 5000, 5)] int secondStart,
                                [Random(5001, 10000, 5)] int secondEnd)
        {
            var result = _range.Overlaps(new Range<int>(firstStart, firstEnd),
                                        new Range<int>(secondStart, secondEnd));
            Assert.False(result);
        }
    }
}

