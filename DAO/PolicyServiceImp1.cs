using Entity;
using Exceptions;
using Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAO
{
    public class PolicyServiceImp1 : IPolicyService
    {
        

        //public PolicyServiceImpl()
        //{
        //}

        public bool CreatePolicy(Policy policy)
        {
            string cnStr = DBConnUtil.ReturnCn("dbCn");
        SqlConnection conn = new SqlConnection(cnStr);
            string query = "INSERT INTO Policy (PolicyId, PolicyName, CoverageAmount) VALUES (@PolicyId, @PolicyName, @CoverageAmount)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PolicyId", policy.PolicyId);
            cmd.Parameters.AddWithValue("@PolicyName", policy.PolicyName);
            cmd.Parameters.AddWithValue("@CoverageAmount", policy.CoverageAmount);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            return rows > 0;
        }

        public Policy GetPolicy(int policyId)
        {
            string cnStr = DBConnUtil.ReturnCn("dbCn");
            SqlConnection conn = new SqlConnection(cnStr);
            string query = "SELECT * FROM Policy WHERE PolicyId = @PolicyId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PolicyId", policyId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Policy policy = new Policy(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                conn.Close();
                return policy;
            }
            conn.Close();
            throw new PolicyNotFoundException($"Policy with ID {policyId} not found.");
        }

        public List<Policy> GetAllPolicies()
        {
            string cnStr = DBConnUtil.ReturnCn("dbCn");
            SqlConnection conn = new SqlConnection(cnStr);
            List<Policy> policies = new List<Policy>();
            string query = "SELECT * FROM Policy";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                policies.Add(new Policy(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2)));
            }
            conn.Close();
            return policies;
        }

        public bool UpdatePolicy(Policy policy)
        {
            string cnStr = DBConnUtil.ReturnCn("dbCn");
            SqlConnection conn = new SqlConnection(cnStr);
            string query = "UPDATE Policy SET PolicyName = @PolicyName, CoverageAmount = @CoverageAmount WHERE PolicyId = @PolicyId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PolicyId", policy.PolicyId);
            cmd.Parameters.AddWithValue("@PolicyName", policy.PolicyName);
            cmd.Parameters.AddWithValue("@CoverageAmount", policy.CoverageAmount);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            return rows > 0;
        }

        public bool DeletePolicy(int policyId)
        {
            string cnStr = DBConnUtil.ReturnCn("dbCn");
            SqlConnection conn = new SqlConnection(cnStr);
            string query = "DELETE FROM Policy WHERE PolicyId = @PolicyId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PolicyId", policyId);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows == 0)
            {
                throw new PolicyNotFoundException($"Policy with ID {policyId} not found.");
            }
            return true;
        }
    }
}
