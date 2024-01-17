using GB.ApiDotNet6.Domain.Validations;
using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Xml.Linq;

namespace GB.ApiDotNet6.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date {  get; private set; }
        public Person Person { get; private set; }
        public Product Product { get; private set; }

        public Purchase(int productId, int personId) 
        {
            Validation(productId, personId);
        }

        public Purchase(int id, int productId, int personId)
        {
            DomainValidationException.When(id < 0, "Id deve ser informado");
            Id = id;
            Validation(productId, personId);
        }
        private void Validation(int productId, int personId)
        {
            DomainValidationException.When(productId <= 0, "Id Produto deve ser informado!");
            DomainValidationException.When(personId <= 0, "Id Pessoa deve ser informado!");

            ProductId = productId;
            PersonId = personId;
            Date = DateTime.Now;
        }
    }
}
