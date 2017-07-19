﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace SharedKernel.BaseAbstractions
{
    public abstract class ValueObjectBase<T> : ValidatableObject, IEquatable<T> where T : ValueObjectBase<T>
    {
        public int Id { get; private set; }
        protected ValueObjectBase() { }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            T other = obj as T;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            IEnumerable<FieldInfo> fields = GetFields();
            int startValue = 17;
            int multiplier = 59;
            int hashCode = startValue;
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(this);
                if (value != null)
                    hashCode = hashCode * multiplier + value.GetHashCode();
            }

            return hashCode;
        }

        public virtual bool Equals(T other)
        {
            if (other == null)
                return false;
            Type t = GetType();
            Type otherType = other.GetType();
            if (t != otherType)
                return false;
            FieldInfo[] fields = t.GetTypeInfo().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (FieldInfo field in fields)
            {
                object value1 = field.GetValue(other);
                object value2 = field.GetValue(this);
                if (value1 == null)
                {
                    if (value2 != null)
                        return false;
                }
                else if (!value1.Equals(value2))
                    return false;
            }

            return true;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            Type t = GetType();
            List<FieldInfo> fields = new List<FieldInfo>();
            while (t != typeof(object))
            {
                fields.AddRange(t.GetTypeInfo().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
                t = t.GetTypeInfo().BaseType;
            }

            return fields;
        }

        public static bool operator ==(ValueObjectBase<T> x, ValueObjectBase<T> y)
        {
            return x != null && x.Equals(y);
        }

        public static bool operator !=(ValueObjectBase<T> x, ValueObjectBase<T> y)
        {
            return !(x == y);
        }
    }
}
