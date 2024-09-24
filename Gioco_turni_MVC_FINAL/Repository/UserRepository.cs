using Microsoft.AspNetCore.Identity;
using Oracle.ManagedDataAccess.Client;
namespace Gioco_turni_MVC_FINAL.Repository
{
    public class UserRepository : IUserStore<IdentityUser>, IUserPasswordStore<IdentityUser>, IUserEmailStore<IdentityUser>
    {
        private string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("OracleDbContext") ?? throw new InvalidOperationException("Connection string not found.");
            _connectionString = connectionString;
        }

        // metodo per aprire connessione con  il db 
        public (bool, OracleConnection) OpenConnectionDb()
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            try
            {

                //await connection.OpenAsync();
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("connessione con il db correttamente eseguita.");
                    Console.WriteLine("------------------------------------");
                    return (true, connection);
                }

                throw new Exception("connessione con il db non riuscita");

            }
            catch (Exception ex)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("------------------------------------");
                return (false, connection);
            }
        }

        public bool ClosingConnection(OracleConnection connection)
        {
            try
            {

                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Connessione con il db chiusa correttamente.");
                    Console.WriteLine("------------------------------------");
                    return true;
                }

                throw new Exception("impossibile chiudere la connessione al db.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Errore durante la chiusura della connessione: {ex.Message}");
                Console.WriteLine("------------------------------------");
                return false;
            }
        }

        // creazione nuovo utente
        public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var (result, conn) = OpenConnectionDb();

            if (!result) return Task.FromResult(IdentityResult.Failed(new IdentityError { Description = "Errore di connessione al database." }));

            try
            {
                // Implementazione della logica di creazione dell'utente
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la creazione dell'utente {ex.Message}");
                return Task.FromResult(IdentityResult.Failed(new IdentityError { Description = "Errore durante la creazione dell'utente." }));
            }
            finally
            {
                ClosingConnection(conn);
            }

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var (result, conn) = OpenConnectionDb();

            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Errore durante la creazione dell'utente {ex.Message}");
            //}
            //finally
            //{
            //    ClosingConnection(conn);
            //}
        }
        public Task<IdentityUser?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(IdentityUser user, string? normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(IdentityUser user, string? passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(IdentityUser user, string? userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(IdentityUser user, string? email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetNormalizedEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(IdentityUser user, string? normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose() { }
    }
}
