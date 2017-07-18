using System;

namespace SharedKernel.BaseAbstractions
{
    public abstract class ValueObjectBase<T> : ValidatableObject, IEquatable<T> where T : ValueObjectBase<T>
    {
        public int Id { get; private set; }
        protected ValueObjectBase(){}
        public abstract bool Equals(T other);
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }
}
