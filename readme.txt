Leads API
=============================
There 3 controllers
1. Leads Controller
2. Cache Controller 
3. Billing Controller
===============================
API is accessible on 
http://localhost:50000/
=============================
1. Leads Controller
Operations
GET http://localhost:50000/api/leads - Get all leads from the in-memory list
GET http://localhost:50000/api/leads/{id} - get lead by provided Lead Id (Guid)
POST http://localhost:50000/api/leads - Create new Lead
Sample JSON for Insert
{
    "Name": "Lead User 1",
    "Phone":"+1-437-437-0000",
    "Zip":"A0A 0A0",
    "Email":"sample@sample.com",
    "HaveConsentToContact":true,
    "Provider":"ABC"
}
------------------------------
2. Cache Controller
POST http://localhost:50000/api/cache/ - Clear cache, it will clear the in-memory list
---------------------------
3. Billing Controller
GET http://localhost:50000/api/billing - Get report of leads, Provider and Total leads provided
=============================
How to run the project
Make sure Leads.RESTAPI is set as a startup project
1. Open the solution in Visual Studio
2. Restore nuget packages
3. Build the project
4. Run the project
Solution is configured to run on port 50000