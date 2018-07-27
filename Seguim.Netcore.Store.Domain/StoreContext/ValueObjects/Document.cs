using Flunt.Br.Validation;
using Flunt.Notifications;
using Flunt.Validations;

namespace Seguim.Netcore.Store.Domain.StoreContext.ValueObjects {
    public class Document : Notifiable
    {
        public Document (string number) {
            Number = number;

            AddNotifications(new Contract()
                .Requires()
                .IsCpf(this.Number, "Document", "This cnpj is not valid")
            );
        }
        
        public string Number { get; private set; }

        public override string ToString () {
            return Number;
        }
    }
}