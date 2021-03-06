﻿namespace BlogSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        NickName = c.String(nullable: false, maxLength: 255),
                        Photo = c.String(nullable: false, maxLength: 255),
                        Images = c.String(nullable: false, maxLength: 255),
                        RolesId = c.Guid(nullable: false),
                        IsRemoved = c.Byte(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RolesId)
                .Index(t => t.RolesId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                        IsRemoved = c.Byte(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdminsPermissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RolesId = c.Guid(nullable: false),
                        SystemMenuId = c.Guid(nullable: false),
                        IsRemoved = c.Byte(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RolesId)
                .ForeignKey("dbo.SystemMenus", t => t.SystemMenuId)
                .Index(t => t.RolesId)
                .Index(t => t.SystemMenuId);
            
            CreateTable(
                "dbo.SystemMenus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                        Link = c.String(maxLength: 255),
                        Icon = c.String(maxLength: 255),
                        ParentId = c.Guid(nullable: false),
                        IsRemoved = c.Byte(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Copyrights",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                        Detail = c.String(nullable: false, maxLength: 255),
                        Telephone = c.String(nullable: false, maxLength: 255),
                        Mobile = c.String(nullable: false, maxLength: 255),
                        Logo = c.String(maxLength: 255),
                        Images = c.String(maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                        QQNumber = c.String(nullable: false, maxLength: 255),
                        QQNumber2 = c.String(nullable: false, maxLength: 255),
                        IsRemoved = c.Byte(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FriendLinks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                        Link = c.String(nullable: false, maxLength: 255),
                        IsRemoved = c.Byte(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                        Keyword = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 2000),
                        WebMenuId = c.Guid(nullable: false),
                        IsRemoved = c.Byte(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WebMenus", t => t.WebMenuId)
                .Index(t => t.WebMenuId);
            
            CreateTable(
                "dbo.WebMenus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                        Link = c.String(nullable: false, maxLength: 255),
                        Icon = c.String(nullable: false, maxLength: 255),
                        ParentId = c.Guid(nullable: false),
                        IsRemoved = c.Byte(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seos", "WebMenuId", "dbo.WebMenus");
            DropForeignKey("dbo.AdminsPermissions", "SystemMenuId", "dbo.SystemMenus");
            DropForeignKey("dbo.AdminsPermissions", "RolesId", "dbo.Roles");
            DropForeignKey("dbo.Admins", "RolesId", "dbo.Roles");
            DropIndex("dbo.Seos", new[] { "WebMenuId" });
            DropIndex("dbo.AdminsPermissions", new[] { "SystemMenuId" });
            DropIndex("dbo.AdminsPermissions", new[] { "RolesId" });
            DropIndex("dbo.Admins", new[] { "RolesId" });
            DropTable("dbo.WebMenus");
            DropTable("dbo.Seos");
            DropTable("dbo.FriendLinks");
            DropTable("dbo.Copyrights");
            DropTable("dbo.SystemMenus");
            DropTable("dbo.AdminsPermissions");
            DropTable("dbo.Roles");
            DropTable("dbo.Admins");
        }
    }
}
