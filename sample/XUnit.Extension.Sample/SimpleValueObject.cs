using System;

namespace XUnit.Extension.Sample
{
    public class SimpleValueObject : IEquatable<SimpleValueObject>
    {
        private readonly string _value1;
        private readonly string _value2;

        public SimpleValueObject(string value1, string value2)
        {
            _value1 = value1?.Trim();
            _value2 = value2?.Trim();
        }

        public bool Equals(SimpleValueObject other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
                string.Equals(_value1, other._value1, StringComparison.InvariantCultureIgnoreCase) 
                && string.Equals(_value2, other._value2, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return 
                obj.GetType() == this.GetType() 
                && Equals((SimpleValueObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return 
                    ((_value1 != null ? _value1.ToLowerInvariant().GetHashCode() : 0) * 397) 
                    ^ (_value2 != null ? _value2.ToLowerInvariant().GetHashCode() : 0);
            }
        }

        public static bool operator ==(SimpleValueObject left, SimpleValueObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SimpleValueObject left, SimpleValueObject right)
        {
            return !Equals(left, right);
        }
    }
}