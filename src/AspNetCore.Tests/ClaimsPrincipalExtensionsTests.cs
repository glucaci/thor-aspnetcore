using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Xunit;

namespace Thor.AspNetCore.Tests
{
    public class ClaimsPrincipalExtensionsTests
    {
        #region GetId

        [Fact(DisplayName = "GetId: Should return null if user is null")]
        public void GetId_UserNull()
        {
            // Arrange
            ClaimsPrincipal user = null;

            // Act
            Guid? userId = user.GetId();

            // Assert
            Assert.Null(userId);
        }

        [Fact(DisplayName = "GetId: Should return null if 'sub' is not found")]
        public void GetId_SubNotFound()
        {
            // Arrange
            Claim[] claims = new Claim[0];
            ClaimsIdentity identity = new ClaimsIdentity(claims);
            ClaimsPrincipal user = new ClaimsPrincipal(identity);

            // Act
            Guid? userId = user.GetId();

            // Assert
            Assert.Null(userId);
        }

        [Fact(DisplayName = "GetId: Should return null if 'sub' value is empty")]
        public void GetId_SubValueEmpty()
        {
            // Arrange
            Claim[] claims =
            {
                new Claim(JwtRegisteredClaimNames.Sub, "")
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims);
            ClaimsPrincipal user = new ClaimsPrincipal(identity);

            // Act
            Guid? userId = user.GetId();

            // Assert
            Assert.Null(userId);
        }

        [Fact(DisplayName = "GetId: Should return null if 'sub' value is invalid")]
        public void GetId_SubValueInvalid()
        {
            // Arrange
            Claim[] claims =
            {
                new Claim(JwtRegisteredClaimNames.Sub, "werweee")
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims);
            ClaimsPrincipal user = new ClaimsPrincipal(identity);

            // Act
            Guid? userId = user.GetId();

            // Assert
            Assert.Null(userId);
        }
        
        [Fact(DisplayName = "GetId: Should return a valid user id")]
        public void GetId_SubValueValid()
        {
            // Arrange
            Guid expectedUserId = Guid.NewGuid();
            Claim[] claims =
            {
                new Claim(JwtRegisteredClaimNames.Sub, expectedUserId.ToString())
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims);
            ClaimsPrincipal user = new ClaimsPrincipal(identity);

            // Act
            Guid? userId = user.GetId();

            // Assert
            Assert.Equal(expectedUserId, userId);
        }

        #endregion
    }
}