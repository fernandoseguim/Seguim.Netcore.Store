using Seguim.Netcore.Store.Domain.StoreContext.ValueObjects;
using Xunit;
using System.Linq;
using System;

namespace Seguim.Netcore.Store.Tests.ValueObjects
{
    public class DocumentTests
    {
        [Fact(DisplayName="Should return notification when document is invalid")]
        public void DocumentIsInvalid()
        {
            var document = new Document("48689215254");
            
            Assert.False(document.Valid);
            Assert.Contains("Document", document.Notifications.ToList().First().Property);
        }
        
        [Fact(DisplayName="Should not return notification when document is valid")]
        public void DocumentIsValid()
        {
            var document = new Document("48689215255");
            
            Assert.True(document.Valid);
            Assert.Empty(document.Notifications);
        }
    }
}