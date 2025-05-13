using AI_Agent_WebApp.Services.Implementations;
using System;

namespace AI_Agent_WebApp.Services.Implementations
{
    public static class PasswordSeedUtil
    {
        public static void PrintHashes()
        {
            var users = new[]
            {
                ("admin", "adminhash"),
                ("user2", "user2hash"),
                ("user3", "user3hash"),
                ("user4", "user4hash"),
                ("supplier1", "supplier1hash"),
                ("supplier2", "supplier2hash"),
                ("supplier3", "supplier3hash"),
                ("supplier4", "supplier4hash")
            };
            foreach (var (user, pass) in users)
            {
                var hash = PasswordHasher.HashPassword(pass);
                Console.WriteLine($"| {user,-10} | {pass,-14} | {hash} |");
            }
        }
    }
}
