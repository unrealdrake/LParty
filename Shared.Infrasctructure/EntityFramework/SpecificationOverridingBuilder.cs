using System;
using System.Collections.Generic;
using System.Reflection;
using SharedKernel.BaseAbstractions.Specification;

namespace Shared.Infrasctructure.EntityFramework
{
    public class SpecificationOverridingBuilder
    {
        private static Dictionary<Type, Type> Overridings = new Dictionary<Type, Type>();

        public static void RegisterOverriding(Type originalSpec, Type destinationSpec)
        {
            Overridings[originalSpec] = destinationSpec;
        }

        public static Specification<T> ReplaceWithOverridings<T>(Specification<T> specificationToOverride) where T : class
        {
            if (specificationToOverride is OrSpecification<T> orSpecification)
            {
                orSpecification.Left = ReplaceWithOverridings(orSpecification.Left);
                orSpecification.Right = ReplaceWithOverridings(orSpecification.Right);
            }
            else if (specificationToOverride is AndSpecification<T> andSpecification)
            {
                andSpecification.Left = ReplaceWithOverridings(andSpecification.Left);
                andSpecification.Right =  ReplaceWithOverridings(andSpecification.Right);
            }
            else
            {
                var overridingExists = Overridings.TryGetValue(specificationToOverride.GetType(), out var overriding);
                if (overridingExists)
                {
                    ConstructorInfo ctor = overriding.GetConstructor(new[] { overriding });
                    object instance = ctor.Invoke(new object[] { specificationToOverride });
                    return (Specification<T>)instance;
                }
            }

            return specificationToOverride;
        }
    }
}
