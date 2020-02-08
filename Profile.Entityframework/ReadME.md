#command for mySQL scaffold database.

dotnet ef dbcontext scaffold "Server=localhost;Database=croudpulse-db;user id=root;password=rootpassword" Pomelo.EntityFrameworkCore.MySql -o EF -c CroudPulseDbContext