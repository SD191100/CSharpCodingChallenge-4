using System.Transactions;
using Entity;
using DAO;
using Microsoft.Data.SqlClient;
using Exceptions;
internal class MainModule
{
    static void Main(string[] args)
    {
        PolicyServiceImp1 policyService = new PolicyServiceImp1();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== Insurance Management System =====");
            Console.WriteLine("1. Create Policy");
            Console.WriteLine("2. View Policy by ID");
            Console.WriteLine("3. View All Policies");
            Console.WriteLine("4. Update Policy");
            Console.WriteLine("5. Delete Policy");
            Console.WriteLine("6. Exit");
            Console.WriteLine("========================================");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreatePolicy(policyService);
                    break;
                case "2":
                    ViewPolicy(policyService);
                    break;
                case "3":
                    ViewAllPolicies(policyService);
                    break;
                case "4":
                    UpdatePolicy(policyService);
                    break;
                case "5":
                    DeletePolicy(policyService);
                    break;
                case "6":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreatePolicy(PolicyServiceImp1 policyService)
    {
        Console.WriteLine("\nEnter Policy Details:");

        Console.Write("Policy ID: ");
        int policyId = int.Parse(Console.ReadLine());

        Console.Write("Policy Name: ");
        string policyName = Console.ReadLine();

        Console.Write("Coverage Amount: ");
        decimal coverageAmount = decimal.Parse(Console.ReadLine());

        Policy newPolicy = new Policy(policyId, policyName, coverageAmount);

        bool success = policyService.CreatePolicy(newPolicy);
        Console.WriteLine(success ? "Policy created successfully." : "Failed to create policy.");
    }

    static void ViewPolicy(PolicyServiceImp1 policyService)
    {
        try
        {
            Console.WriteLine("\nEnter Policy ID to View:");
            int policyId = int.Parse(Console.ReadLine());

            Policy policy = policyService.GetPolicy(policyId);

            Console.WriteLine($"\nPolicy ID: {policy.PolicyId}");
            Console.WriteLine($"Policy Name: {policy.PolicyName}");
            Console.WriteLine($"Coverage Amount: {policy.CoverageAmount}");
        }
        catch (PolicyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ViewAllPolicies(PolicyServiceImp1 policyService)
    {
        Console.WriteLine("\nAll Policies:");

        var policies = policyService.GetAllPolicies();

        foreach (var policy in policies)
        {
            Console.WriteLine($"Policy ID: {policy.PolicyId}, Name: {policy.PolicyName}, Coverage: {policy.CoverageAmount}");
        }
    }

    static void UpdatePolicy(PolicyServiceImp1 policyService)
    {
        Console.WriteLine("\nEnter Policy ID to Update:");
        int policyId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Updated Policy Details:");
        Console.Write("Updated Policy Name: ");
        string policyName = Console.ReadLine();

        Console.Write("Updated Coverage Amount: ");
        decimal coverageAmount = decimal.Parse(Console.ReadLine());

        Policy updatedPolicy = new Policy(policyId, policyName, coverageAmount);

        bool success = policyService.UpdatePolicy(updatedPolicy);
        Console.WriteLine(success ? "Policy updated successfully." : "Failed to update policy.");
    }

    static void DeletePolicy(PolicyServiceImp1 policyService)
    {
        try
        {
            Console.WriteLine("\nEnter Policy ID to Delete:");
            int policyId = int.Parse(Console.ReadLine());

            bool success = policyService.DeletePolicy(policyId);
            Console.WriteLine(success ? "Policy deleted successfully." : "Failed to delete policy.");
        }
        catch (PolicyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}