using System;

namespace SharedKernel.BaseAbstractions
{
    public abstract class ValueObjectBase<T> : ValidatableObject, IEquatable<T> where T : ValueObjectBase<T>
    {
        public abstract bool Equals(T other);
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }
}
