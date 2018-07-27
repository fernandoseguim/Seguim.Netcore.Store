using Seguim.Netcore.Store.Domain.StoreContext.ValueObjects;
using Xunit;
using System.Linq;
using System;

namespace Seguim.Netcore.Store.Tests.ValueObjects
{
    public class NameTests
    {
        [Fact(DisplayName="Should return notification when first name is invalid")]
        public void FirstIsInvalid()
        {
            var name = new Name("Fe", "Sesguim");
            
            Assert.False(name.Valid);
            Assert.Contains("FirstName", name.Notifications.ToList().First().Property);
        }

        [Fact(DisplayName="Should return notification when last name is invalid")]
        public void LastNameIsInvalid()
        {
            var name = new Name("Fernando", "S");
            
            Assert.False(name.Valid);
            Assert.Contains("LastName", name.Notifications.ToList().First().Property);
        }
        
        [Fact(DisplayName="Should return notification when full name is invalid")]
        public void FullNameIsInvalid()
        {
            var name = new Name("Fe", "S");
            
            Assert.False(name.Valid);
            Assert.True(name.Notifications.ToList().Any(x => x.Property.Equals(nameof(name.FirstName))));
            Assert.True(name.Notifications.ToList().Any(x => x.Property.Equals(nameof(name.LastName))));
        }
        
        [Fact(DisplayName="Should not return notification when name is valid")]
        public void DocumentIsValid()
        {
            var document = new Name("Fernando", "Seguim");
            
            Assert.True(document.Valid);
            Assert.Empty(document.Notifications);
        }
    }
}