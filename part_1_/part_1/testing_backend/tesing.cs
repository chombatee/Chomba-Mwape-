using part_1.Models;
using System.Collections;

namespace testing_backend
{
    public class tesing
    {


        loads_all test_all = new loads_all();
        // ----- Tests for loads_all class -----

        [Fact]
        public void CorrectLogin_ShouldReturnLoginSuccessfully()
        {
            // Arrange
            var loginClass = new loads_all();
            string email = "test@example.com";
            string role = "admin";
            string password = "password123";

            // Act
            string result = loginClass.login(email, role, password);

            // Assert
            Assert.Equal("login successfully", result);
        }

        [Fact]
        public void IncorrectLogin_ShouldReturnLoginNotSuccessfully()
        {
            // Arrange
            var loginClass = new loads_all();
            string email = "wrong@example.com";
            string role = "admin";
            string password = "wrongPassword";

            // Act
            string result = loginClass.login(email, role, password);

            // Assert
            Assert.Equal("login not successfully", result);
        }

        // ----- Tests for claim class -----

        [Fact]
        public void StoreClaim_ShouldReturnDone()
        {
            // Arrange
            var claimClass = new claim();
            string username = "test_user";
            string module = "HR";
            string claim_date = "2024-10-24";
            string period = "Oct 2024";
            string hour_rate = "50";
            string hours_worked = "8";
            string description = "Claim for project work";
            string filename = "supporting_doc.pdf";
            string filepath = "/docs/supporting_doc.pdf";

            // Act
            string result = claimClass.store(username, module, claim_date, period, hour_rate, hours_worked, description, filename, filepath);

            // Assert
            Assert.Equal("done", result);
        }

        [Fact]
        public void StoreClaim_ShouldFailOnInvalidData()
        {
            // Arrange
            var claimClass = new claim();
            string username = "";
            string module = "";
            string claim_date = "invalid-date";
            string period = "";
            string hour_rate = "-50"; // Invalid value
            string hours_worked = "0"; // Invalid value
            string description = "Invalid claim";
            string filename = "";
            string filepath = "";

            // Act
            string result = claimClass.store(username, module, claim_date, period, hour_rate, hours_worked, description, filename, filepath);

            // Assert
            Assert.NotEqual("done", result);
        }

        // ----- Tests for get_cliams class -----

        [Fact]
        public void GetClaims_ShouldLoadClaimsSuccessfully()
        {
            // Arrange
            var getClaimsClass = new get_cliams();

            // Act
            ArrayList usernames = getClaimsClass.username;
            ArrayList modules = getClaimsClass.module;

            // Assert
            Assert.NotEmpty(usernames); // Ensure usernames are loaded
            Assert.NotEmpty(modules);   // Ensure modules are loaded
        }

        [Fact]
        public void GetClaims_ShouldHandleNoClaims()
        {
            // Arrange
            var getClaimsClass = new get_cliams();

            // Act
            ArrayList usernames = getClaimsClass.username;

            // Assert
            Assert.Empty(usernames); // Test for no claims
        }

        // ----- Tests for loginModel class -----

        [Fact]
        public void LoginModel_ShouldSetAndGetValues()
        {
            // Arrange
            var loginModel = new loginModel
            {
                Username = "user1",
                Password = "pass123",
                WorkType = "FullTime"
            };

            // Act & Assert
            Assert.Equal("user1", loginModel.Username);
            Assert.Equal("pass123", loginModel.Password);
            Assert.Equal("FullTime", loginModel.WorkType);
        }

        // ----- Tests for loads_all class (claim-related methods) -----

        [Fact]
        public void LoadsAll_ShouldLoadPendingClaims()
        {
            // Arrange
            var loadsAllClass = new loads_all();

            // Act
            ArrayList pendingClaims = loadsAllClass.status;

            // Assert
            Assert.NotEmpty(pendingClaims); // Ensure pending claims are loaded
        }

        [Fact]
        public void LoadsAll_ShouldHandleNoPendingClaims()
        {
            // Arrange
            var loadsAllClass = new loads_all();

            // Act
            ArrayList pendingClaims = loadsAllClass.status;

            // Assert
            Assert.Empty(pendingClaims); // Test for no pending claims
        }

        [Fact]
        public void LoadsAll_ShouldLoadClaimDetails()
        {
            // Arrange
            var loadsAllClass = new loads_all();

            // Act
            ArrayList claimDates = loadsAllClass.claim_date;
            ArrayList modules = loadsAllClass.module;

            // Assert
            Assert.NotEmpty(claimDates);  // Ensure claim dates are loaded
            Assert.NotEmpty(modules);     // Ensure modules are loaded
        }
        public class loads_all
        {
            public ArrayList username { get; set; } = new ArrayList();
            public ArrayList module { get; set; } = new ArrayList();
            public ArrayList claim_date { get; set; } = new ArrayList();
            public ArrayList period { get; set; } = new ArrayList();
            public ArrayList hour_rate { get; set; } = new ArrayList();
            public ArrayList hours_worked { get; set; } = new ArrayList();
            public ArrayList supporting_document { get; set; } = new ArrayList();
            public ArrayList description { get; set; } = new ArrayList();
            public ArrayList total { get; set; } = new ArrayList();
            public ArrayList status { get; set; } = new ArrayList();
            public ArrayList id { get; set; } = new ArrayList();

            public string login(string email, string role, string password)
            {
                if (email == "john@gmail.com" && password == "12345" && role == "lecture")
                {
                    return "login successfully";
                }
                else
                {
                    return "login not successfully";
                }
            }
        }

        public class claim
        {
            public string store(string username, string module, string claim_date, string period, string hour_rate, string hours_worked, string description, string filename, string filepath)
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(claim_date) || string.IsNullOrEmpty(hour_rate) || string.IsNullOrEmpty(hours_worked))
                {
                    return "";
                }

                try
                {
                    double total = double.Parse(hour_rate) * double.Parse(hours_worked);
                    return "done";
                }
                catch (FormatException)
                {
                    return "";
                }
            }
        }

        public class TestSuite
        {
            // Test login functionality
            [Fact]
            public void correct_login()
            {
                loads_all test_all = new loads_all();
                string expected = "login successfully";
                string result = test_all.login("john@gmail.com", "lecture", "12345");
                Assert.Equal(expected, result);
            }

            [Fact]
            public void incorrect_login_email()
            {
                loads_all test_all = new loads_all();
                string expected = "login not successfully";
                string result = test_all.login("wrong_email@gmail.com", "lecture", "12345");
                Assert.Equal(expected, result);
            }

            [Fact]
            public void incorrect_login_password()
            {
                loads_all test_all = new loads_all();
                string expected = "login not successfully";
                string result = test_all.login("john@gmail.com", "lecture", "wrong_password");
                Assert.Equal(expected, result);
            }

            [Fact]
            public void incorrect_login_role()
            {
                loads_all test_all = new loads_all();
                string expected = "login not successfully";
                string result = test_all.login("john@gmail.com", "admin", "12345");
                Assert.Equal(expected, result);
            }

            [Fact]
            public void login_empty_email()
            {
                loads_all test_all = new loads_all();
                string expected = "login not successfully";
                string result = test_all.login("", "lecture", "12345");
                Assert.Equal(expected, result);
            }

            // Test claim submission functionality
            [Fact]
            public void valid_claim_submission()
            {
                claim claimObj = new claim();
                string expected = "done";
                string result = claimObj.store("john@gmail.com", "Prog6112", "2024-10-23", "October", "100", "10", "Teaching hours", "file.pdf", "path/to/file");
                Assert.Equal(expected, result);
            }

            [Fact]
            public void missing_claim_date()
            {
                claim claimObj = new claim();
                string expected = ""; // Expecting an empty result for invalid input
                string result = claimObj.store("john@gmail.com", "Prog6112", "", "October", "100", "10", "Teaching hours", "file.pdf", "path/to/file");
                Assert.Equal(expected, result);
            }

            [Fact]
            public void invalid_hour_rate_claim()
            {
                claim claimObj = new claim();
                string expected = ""; // Expecting an empty result for invalid hour rate
                string result = claimObj.store("john@gmail.com", "Prog6112", "2024-10-23", "October", "invalid_rate", "10", "Teaching hours", "file.pdf", "path/to/file");
                Assert.Equal(expected, result);
            }

            [Fact]
            public void empty_username_in_claim_submission()
            {
                claim claimObj = new claim();
                string expected = ""; // Expecting an empty result for missing username
                string result = claimObj.store("", "Prog6112", "2024-10-23", "October", "100", "10", "Teaching hours", "file.pdf", "path/to/file");
                Assert.Equal(expected, result);
            }

            [Fact]
            public void empty_hours_worked_claim_submission()
            {
                claim claimObj = new claim();
                string expected = ""; // Expecting an empty result for missing hours worked
                string result = claimObj.store("john@gmail.com", "Prog6112", "2024-10-23", "October", "100", "", "Teaching hours", "file.pdf", "path/to/file");
                Assert.Equal(expected, result);
            }
        }

    }
}