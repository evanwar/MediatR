using System;


namespace CQR.Entities.Exceptions
{
    public class EntityNotFoundException : Exception
    {

        public string Entity { get; }
        public object key { get; }
        public EntityNotFoundException() { }
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public EntityNotFoundException(string entity, object key) : base($"{entity} {key} no encontrado.")
        {
            this.Entity = entity;
            this.key = key;
        }

    }
}
