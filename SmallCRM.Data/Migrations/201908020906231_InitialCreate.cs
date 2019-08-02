namespace SmallCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContactFullName = c.String(),
                        Subject = c.String(nullable: false, maxLength: 100),
                        CallReason = c.Int(),
                        RelatedRecord = c.Int(),
                        CallDirection = c.Int(nullable: false),
                        CallDetail = c.Int(),
                        CallResult = c.Int(),
                        ContactId = c.Guid(),
                        Description = c.String(),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        CompanyTelephone = c.String(),
                        CompanyWebsite = c.String(),
                        CompanyId = c.Guid(),
                        OpportunityName = c.String(nullable: false, maxLength: 100),
                        OpportunityAmount = c.Decimal(precision: 18, scale: 2),
                        OpportunityCloseDate = c.DateTime(nullable: false),
                        OpportunityType = c.Int(nullable: false),
                        OpportunityStage = c.Int(nullable: false),
                        OpportunityId = c.Guid(),
                        CampaignName = c.String(nullable: false, maxLength: 100),
                        CampaignStatus = c.Int(),
                        CampaignStartDate = c.DateTime(),
                        CampaignEndDate = c.DateTime(),
                        CampaignExpectedRevenue = c.Decimal(precision: 18, scale: 2),
                        CampaignId = c.Guid(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .ForeignKey("dbo.Opportunities", t => t.OpportunityId)
                .Index(t => t.ContactId)
                .Index(t => t.CompanyId)
                .Index(t => t.OpportunityId)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Owner = c.String(maxLength: 100),
                        OpportunityType = c.Int(nullable: false),
                        CampaignStatus = c.Int(),
                        Name = c.String(nullable: false, maxLength: 100),
                        StartDate = c.DateTime(),
                        ExpectedRevenue = c.Decimal(precision: 18, scale: 2),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        SendPhoneNumbers = c.String(),
                        EndDate = c.DateTime(),
                        PlannedCost = c.Decimal(precision: 18, scale: 2),
                        ExpectedResponse = c.String(maxLength: 100),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Owner = c.String(maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        MainCompanyId = c.Guid(),
                        CompanyNumber = c.String(maxLength: 20),
                        CompanyTypeId = c.Guid(),
                        SectorId = c.Guid(),
                        AnnualIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stage = c.Int(),
                        Telephone = c.String(maxLength: 20),
                        Fax = c.String(maxLength: 20),
                        Website = c.String(maxLength: 50),
                        ImkbCode = c.String(maxLength: 50),
                        OwnerShip = c.Int(),
                        NaceCode = c.String(maxLength: 50),
                        InvoiceAddress = c.String(maxLength: 500),
                        InvoiceCityId = c.Guid(),
                        InvoiceRegionId = c.Guid(),
                        InvoicePostalCode = c.String(maxLength: 50),
                        InvoiceDescription = c.String(maxLength: 4000),
                        InvoiceCountryId = c.Guid(),
                        DeliveryAddress = c.String(maxLength: 500),
                        DeliveryCityId = c.Guid(),
                        DeliveryRegionId = c.Guid(),
                        DeliveryPostalCode = c.String(maxLength: 50),
                        DeliveryDescription = c.String(maxLength: 4000),
                        DeliveryCountryId = c.Guid(),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyTypes", t => t.CompanyTypeId)
                .ForeignKey("dbo.Cities", t => t.DeliveryCityId)
                .ForeignKey("dbo.Countries", t => t.DeliveryCountryId)
                .ForeignKey("dbo.Regions", t => t.DeliveryRegionId)
                .ForeignKey("dbo.Cities", t => t.InvoiceCityId)
                .ForeignKey("dbo.Countries", t => t.InvoiceCountryId)
                .ForeignKey("dbo.Regions", t => t.InvoiceRegionId)
                .ForeignKey("dbo.Companies", t => t.MainCompanyId)
                .ForeignKey("dbo.Sectors", t => t.SectorId)
                .Index(t => t.MainCompanyId)
                .Index(t => t.CompanyTypeId)
                .Index(t => t.SectorId)
                .Index(t => t.InvoiceCityId)
                .Index(t => t.InvoiceRegionId)
                .Index(t => t.InvoiceCountryId)
                .Index(t => t.DeliveryCityId)
                .Index(t => t.DeliveryRegionId)
                .Index(t => t.DeliveryCountryId);
            
            CreateTable(
                "dbo.CompanyTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Owner = c.String(maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        TitleOfCourtesy = c.Int(),
                        CompanyId = c.Guid(),
                        Email = c.String(maxLength: 100),
                        Telephone = c.String(maxLength: 20),
                        OtherPhone = c.String(maxLength: 20),
                        HomePhone = c.String(maxLength: 20),
                        MobilePhone = c.String(maxLength: 20),
                        AssistantName = c.String(maxLength: 100),
                        AssistantPhone = c.String(maxLength: 20),
                        LeadSourceId = c.Guid(),
                        Title = c.String(maxLength: 100),
                        Department = c.String(maxLength: 100),
                        Fax = c.String(maxLength: 20),
                        BirthDate = c.DateTime(),
                        NotSendEmail = c.Boolean(nullable: false),
                        NotSendSms = c.Boolean(nullable: false),
                        SkypeId = c.String(maxLength: 100),
                        Twitter = c.String(maxLength: 100),
                        SecondaryEmail = c.String(maxLength: 100),
                        ReportsToContactId = c.Guid(),
                        Photo = c.String(maxLength: 200),
                        Address = c.String(maxLength: 500),
                        CountryId = c.Guid(),
                        CityId = c.Guid(),
                        RegionId = c.Guid(),
                        PostalCode = c.String(maxLength: 10),
                        OtherAddress = c.String(maxLength: 500),
                        OtherCountryId = c.Guid(),
                        OtherCityId = c.Guid(),
                        OtherRegionId = c.Guid(),
                        OtherPostalCode = c.String(maxLength: 10),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.LeadSources", t => t.LeadSourceId)
                .ForeignKey("dbo.Cities", t => t.OtherCityId)
                .ForeignKey("dbo.Countries", t => t.OtherCountryId)
                .ForeignKey("dbo.Regions", t => t.OtherRegionId)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .ForeignKey("dbo.Contacts", t => t.ReportsToContactId)
                .Index(t => t.CompanyId)
                .Index(t => t.LeadSourceId)
                .Index(t => t.ReportsToContactId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
                .Index(t => t.RegionId)
                .Index(t => t.OtherCountryId)
                .Index(t => t.OtherCityId)
                .Index(t => t.OtherRegionId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        CountryId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Owner = c.String(maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Company = c.String(nullable: false, maxLength: 100),
                        TitleOfCourtesy = c.Int(),
                        Gender = c.Int(),
                        Title = c.String(maxLength: 100),
                        Telephone = c.String(maxLength: 20),
                        MobilePhone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        Fax = c.String(maxLength: 20),
                        LeadSourceId = c.Guid(),
                        SectorId = c.Guid(),
                        NotSendEmail = c.Boolean(nullable: false),
                        NotSendSms = c.Boolean(nullable: false),
                        Website = c.String(),
                        LeadStatusId = c.Guid(),
                        Stage = c.Int(),
                        SkypeId = c.String(maxLength: 100),
                        Twitter = c.String(maxLength: 100),
                        SecondaryEmail = c.String(maxLength: 100),
                        Photo = c.String(maxLength: 200),
                        Address = c.String(maxLength: 500),
                        CountryId = c.Guid(),
                        CityId = c.Guid(),
                        RegionId = c.Guid(),
                        PostalCode = c.String(maxLength: 10),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                        Company_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.LeadSources", t => t.LeadSourceId)
                .ForeignKey("dbo.LeadStatus", t => t.LeadStatusId)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .ForeignKey("dbo.Sectors", t => t.SectorId)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.LeadSourceId)
                .Index(t => t.SectorId)
                .Index(t => t.LeadStatusId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
                .Index(t => t.RegionId)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.LeadSources",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Opportunities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Owner = c.String(maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        CompanyId = c.Guid(nullable: false),
                        OpportunityType = c.Int(),
                        NextStep = c.String(maxLength: 100),
                        LeadSourceId = c.Guid(),
                        ContactId = c.Guid(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CloseDate = c.DateTime(nullable: false),
                        OpportunityStage = c.Int(nullable: false),
                        Possibility = c.Int(nullable: false),
                        ExpectedRevenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CampaignSourceId = c.Guid(),
                        Description = c.String(maxLength: 4000),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CampaignSources", t => t.CampaignSourceId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .ForeignKey("dbo.LeadSources", t => t.LeadSourceId)
                .Index(t => t.CompanyId)
                .Index(t => t.LeadSourceId)
                .Index(t => t.ContactId)
                .Index(t => t.CampaignSourceId);
            
            CreateTable(
                "dbo.CampaignSources",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeadStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        CityId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        File = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 4000),
                        FileType = c.Int(nullable: false),
                        Extension = c.String(),
                        Size = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Message = c.String(nullable: false, maxLength: 4000),
                        DocumentId = c.Guid(),
                        IsRead = c.Boolean(nullable: false),
                        TargetUser = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .Index(t => t.DocumentId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        Managers = c.String(maxLength: 4000),
                        BussinessAnalyists = c.String(maxLength: 4000),
                        Developers = c.String(maxLength: 4000),
                        StartDate = c.DateTime(),
                        WorkItemStatus = c.Int(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeSpendings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ProjectId = c.Guid(nullable: false),
                        WorkItemId = c.Guid(),
                        Worker = c.String(nullable: false, maxLength: 100),
                        TimeSpent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WorkItemStatus = c.Int(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.WorkItems", t => t.WorkItemId)
                .Index(t => t.ProjectId)
                .Index(t => t.WorkItemId);
            
            CreateTable(
                "dbo.WorkItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        AssignedTo = c.String(maxLength: 100),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Category = c.String(maxLength: 100),
                        WorkItemStatus = c.Int(),
                        ProjectId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 4000),
                        LastExecutionDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TimeSpendings", "WorkItemId", "dbo.WorkItems");
            DropForeignKey("dbo.WorkItems", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.TimeSpendings", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Feeds", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Activities", "OpportunityId", "dbo.Opportunities");
            DropForeignKey("dbo.Activities", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Activities", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Companies", "MainCompanyId", "dbo.Companies");
            DropForeignKey("dbo.Leads", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Companies", "InvoiceRegionId", "dbo.Regions");
            DropForeignKey("dbo.Companies", "InvoiceCountryId", "dbo.Countries");
            DropForeignKey("dbo.Companies", "InvoiceCityId", "dbo.Cities");
            DropForeignKey("dbo.Companies", "DeliveryRegionId", "dbo.Regions");
            DropForeignKey("dbo.Companies", "DeliveryCountryId", "dbo.Countries");
            DropForeignKey("dbo.Companies", "DeliveryCityId", "dbo.Cities");
            DropForeignKey("dbo.Contacts", "ReportsToContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Contacts", "OtherRegionId", "dbo.Regions");
            DropForeignKey("dbo.Contacts", "OtherCountryId", "dbo.Countries");
            DropForeignKey("dbo.Contacts", "OtherCityId", "dbo.Cities");
            DropForeignKey("dbo.Contacts", "LeadSourceId", "dbo.LeadSources");
            DropForeignKey("dbo.Contacts", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Contacts", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Leads", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Leads", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Regions", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Leads", "LeadStatusId", "dbo.LeadStatus");
            DropForeignKey("dbo.Leads", "LeadSourceId", "dbo.LeadSources");
            DropForeignKey("dbo.Opportunities", "LeadSourceId", "dbo.LeadSources");
            DropForeignKey("dbo.Opportunities", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Opportunities", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Opportunities", "CampaignSourceId", "dbo.CampaignSources");
            DropForeignKey("dbo.Leads", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Leads", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Companies", "CompanyTypeId", "dbo.CompanyTypes");
            DropForeignKey("dbo.Activities", "CampaignId", "dbo.Campaigns");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.WorkItems", new[] { "ProjectId" });
            DropIndex("dbo.TimeSpendings", new[] { "WorkItemId" });
            DropIndex("dbo.TimeSpendings", new[] { "ProjectId" });
            DropIndex("dbo.Feeds", new[] { "DocumentId" });
            DropIndex("dbo.Regions", new[] { "CityId" });
            DropIndex("dbo.Opportunities", new[] { "CampaignSourceId" });
            DropIndex("dbo.Opportunities", new[] { "ContactId" });
            DropIndex("dbo.Opportunities", new[] { "LeadSourceId" });
            DropIndex("dbo.Opportunities", new[] { "CompanyId" });
            DropIndex("dbo.Leads", new[] { "Company_Id" });
            DropIndex("dbo.Leads", new[] { "RegionId" });
            DropIndex("dbo.Leads", new[] { "CityId" });
            DropIndex("dbo.Leads", new[] { "CountryId" });
            DropIndex("dbo.Leads", new[] { "LeadStatusId" });
            DropIndex("dbo.Leads", new[] { "SectorId" });
            DropIndex("dbo.Leads", new[] { "LeadSourceId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Contacts", new[] { "OtherRegionId" });
            DropIndex("dbo.Contacts", new[] { "OtherCityId" });
            DropIndex("dbo.Contacts", new[] { "OtherCountryId" });
            DropIndex("dbo.Contacts", new[] { "RegionId" });
            DropIndex("dbo.Contacts", new[] { "CityId" });
            DropIndex("dbo.Contacts", new[] { "CountryId" });
            DropIndex("dbo.Contacts", new[] { "ReportsToContactId" });
            DropIndex("dbo.Contacts", new[] { "LeadSourceId" });
            DropIndex("dbo.Contacts", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "DeliveryCountryId" });
            DropIndex("dbo.Companies", new[] { "DeliveryRegionId" });
            DropIndex("dbo.Companies", new[] { "DeliveryCityId" });
            DropIndex("dbo.Companies", new[] { "InvoiceCountryId" });
            DropIndex("dbo.Companies", new[] { "InvoiceRegionId" });
            DropIndex("dbo.Companies", new[] { "InvoiceCityId" });
            DropIndex("dbo.Companies", new[] { "SectorId" });
            DropIndex("dbo.Companies", new[] { "CompanyTypeId" });
            DropIndex("dbo.Companies", new[] { "MainCompanyId" });
            DropIndex("dbo.Activities", new[] { "CampaignId" });
            DropIndex("dbo.Activities", new[] { "OpportunityId" });
            DropIndex("dbo.Activities", new[] { "CompanyId" });
            DropIndex("dbo.Activities", new[] { "ContactId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reports");
            DropTable("dbo.WorkItems");
            DropTable("dbo.TimeSpendings");
            DropTable("dbo.Projects");
            DropTable("dbo.Feeds");
            DropTable("dbo.Documents");
            DropTable("dbo.Sectors");
            DropTable("dbo.Regions");
            DropTable("dbo.LeadStatus");
            DropTable("dbo.CampaignSources");
            DropTable("dbo.Opportunities");
            DropTable("dbo.LeadSources");
            DropTable("dbo.Leads");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Contacts");
            DropTable("dbo.CompanyTypes");
            DropTable("dbo.Companies");
            DropTable("dbo.Campaigns");
            DropTable("dbo.Activities");
        }
    }
}
