using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class LoanApplicationController : ControllerBase
{
    // Hardcoded list of loan applications for simulation
    private static List<LoanApplication> loanApplications = new List<LoanApplication>
    {
        // Hardcoded loan application data for simulation
        new LoanApplication
        {
            Id = 1,
            Borrower = new Borrower { Id = 101, FirstName = "John", Surname = "Doe", Income = 50000 },
            Amount = 10000,
            Status = "Submitted",
            Date = DateTime.Now.AddDays(-5)
        },
        new LoanApplication
        {
            Id = 2,
            Borrower = new Borrower { Id = 102, FirstName = "Jane", Surname = "Smith", Income = 60000 },
            Amount = 15000,
            Status = "Approved",
            Date = DateTime.Now.AddDays(-3)
        },
        new LoanApplication
        {
            Id = 3,
            Borrower = new Borrower { Id = 103, FirstName = "Bob", Surname = "Johnson", Income = 75000 },
            Amount = 12000,
            Status = "Rejected",
            Date = DateTime.Now.AddDays(-1)
        }
    };

    // GET: api/LoanApplication
    [HttpGet]
    public IActionResult GetLoanApplications()
    {
        // Retrieve all loan applications
        return Ok(loanApplications);
    }

    // GET: api/LoanApplication/1
    [HttpGet("{id}")]
    public IActionResult GetLoanApplication(int id)
    {
        // Retrieve a specific loan application by ID
        var loanApp = loanApplications.Find(app => app.Id == id);
        if (loanApp == null)
            return NotFound("Loan application not found.");

        return Ok(loanApp);
    }

    // GET: api/LoanApplication/status/approved
    [HttpGet("status/{status}")]
    public IActionResult GetLoanApplicationsByStatus(string status)
    {
        // Retrieve all loan applications with a specific status
        var filteredApps = loanApplications.FindAll(app => app.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        return Ok(filteredApps);
    }

    // GET: api/LoanApplication/borrower/1
    [HttpGet("borrower/{borrowerId}")]
    public IActionResult GetLoanApplicationsByBorrower(int borrowerId)
    {
        // Retrieve all loan applications made by a specific borrower based on borrower ID
        var borrowerApps = loanApplications.FindAll(app => app.Borrower.Id == borrowerId);
        return Ok(borrowerApps);
    }

    // POST: api/LoanApplication
    [HttpPost]
    public IActionResult CreateLoanApplication([FromBody] LoanApplication loanApp)
    {
        // Create a new loan application
        loanApp.Id = loanApplications.Count + 1;
        loanApp.Date = DateTime.Now;
        loanApplications.Add(loanApp);

        return CreatedAtAction(nameof(GetLoanApplication), new { id = loanApp.Id }, loanApp);
    }

    // PUT: api/LoanApplication/1
    [HttpPut("{id}")]
    public IActionResult UpdateLoanApplication(int id, [FromBody] LoanApplication updatedLoanApp)
    {
        // Update an existing loan application by providing its ID and the updated information
        var existingLoanApp = loanApplications.Find(app => app.Id == id);
        if (existingLoanApp == null)
            return NotFound("Loan application not found.");

        existingLoanApp.Amount = updatedLoanApp.Amount;
        existingLoanApp.Status = updatedLoanApp.Status;

        return Ok(existingLoanApp);
    }

    // DELETE: api/LoanApplication/1
    [HttpDelete("{id}")]
    public IActionResult DeleteLoanApplication(int id)
    {
        // Delete an existing loan application by providing its ID
        var loanApp = loanApplications.Find(app => app.Id == id);
        if (loanApp == null)
            return NotFound("Loan application not found.");

        loanApplications.Remove(loanApp);
        return NoContent();
    }
}
