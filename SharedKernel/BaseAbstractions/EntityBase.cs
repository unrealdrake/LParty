using System;

namespace SharedKernel.Domain
{
    public abstract class EntityBase<IdType> : IEquatable<EntityBase<IdType>>
    {
        private readonly IdType _id;

        protected EntityBase(IdType id)
        {
            _id = id;
        }

        private IdType Id => _id;

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
