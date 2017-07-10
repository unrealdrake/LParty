using System;

namespace SharedKernel.BaseAbstractions
{
    public abstract class EntityBase<IdType> : ValidatableObject, IEquatable<EntityBase<IdType>>
    {
        #region Validation

        #endregion

        public IdType Id { get; protected set; }

        public override bool Equals(object entity)
        {
            return entity is EntityBase<IdType> && this == (EntityBase<IdType>)entity;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<IdType> sourceEntity, EntityBase<IdType> targetEntity)
        {
            if ((object)sourceEntity == null && (object)targetEntity == null)
            {
                return true;
            }

            if ((object)sourceEntity == null || (object)targetEntity == null)
            {
                return false;
            }

            if (sourceEntity.Id.ToString() == targetEntity.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<IdType> sourceEntity, EntityBase<IdType> targetEntity)
        {
            return !(sourceEntity == targetEntity);
        }

        public bool Equals(EntityBase<IdType> other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }
    }
}
