using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fast.Template.Start.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "abpauditlogs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    applicationname = table.Column<string>(type: "character varying(96)", maxLength: 96, nullable: true),
                    userid = table.Column<Guid>(type: "uuid", nullable: true),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    tenantname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    impersonatoruserid = table.Column<Guid>(type: "uuid", nullable: true),
                    impersonatorusername = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    impersonatortenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    impersonatortenantname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    executiontime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    executionduration = table.Column<int>(type: "integer", nullable: false),
                    clientipaddress = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    clientname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    clientid = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    correlationid = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    browserinfo = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    httpmethod = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    url = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    exceptions = table.Column<string>(type: "text", nullable: true),
                    comments = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    httpstatuscode = table.Column<int>(type: "integer", nullable: true),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpauditlogs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abpbackgroundjobs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    jobname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    jobargs = table.Column<string>(type: "character varying(1048576)", maxLength: 1048576, nullable: false),
                    trycount = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    nexttrytime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lasttrytime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    isabandoned = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    priority = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)15),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpbackgroundjobs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abpclaimtypes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    required = table.Column<bool>(type: "boolean", nullable: false),
                    isstatic = table.Column<bool>(type: "boolean", nullable: false),
                    regex = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    regexdescription = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    valuetype = table.Column<int>(type: "integer", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpclaimtypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abpfeaturegroups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    displayname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpfeaturegroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abpfeatures",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    groupname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    parentname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    displayname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    defaultvalue = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    isvisibletoclients = table.Column<bool>(type: "boolean", nullable: false),
                    isavailabletohost = table.Column<bool>(type: "boolean", nullable: false),
                    allowedproviders = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    valuetype = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    extraproperties = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpfeatures", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abpfeaturevalues",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    value = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    providername = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    providerkey = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpfeaturevalues", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abplinkusers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sourceuserid = table.Column<Guid>(type: "uuid", nullable: false),
                    sourcetenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    targetuserid = table.Column<Guid>(type: "uuid", nullable: false),
                    targettenantid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abplinkusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abporganizationunits",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    code = table.Column<string>(type: "character varying(95)", maxLength: 95, nullable: false),
                    displayname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    entityversion = table.Column<int>(type: "integer", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true),
                    lastmodificationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastmodifierid = table.Column<Guid>(type: "uuid", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    deleterid = table.Column<Guid>(type: "uuid", nullable: true),
                    deletiontime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abporganizationunits", x => x.id);
                    table.ForeignKey(
                        name: "fk_abporganizationunits_abporganizationunits_parentid",
                        column: x => x.parentid,
                        principalTable: "abporganizationunits",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "abppermissiongrants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    providername = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    providerkey = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abppermissiongrants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abppermissiongroups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    displayname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abppermissiongroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abppermissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    groupname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    parentname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    displayname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    isenabled = table.Column<bool>(type: "boolean", nullable: false),
                    multitenancyside = table.Column<byte>(type: "smallint", nullable: false),
                    providers = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    statecheckers = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    extraproperties = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abppermissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abproles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    normalizedname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    isdefault = table.Column<bool>(type: "boolean", nullable: false),
                    isstatic = table.Column<bool>(type: "boolean", nullable: false),
                    ispublic = table.Column<bool>(type: "boolean", nullable: false),
                    entityversion = table.Column<int>(type: "integer", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abproles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abpsecuritylogs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    applicationname = table.Column<string>(type: "character varying(96)", maxLength: 96, nullable: true),
                    identity = table.Column<string>(type: "character varying(96)", maxLength: 96, nullable: true),
                    action = table.Column<string>(type: "character varying(96)", maxLength: 96, nullable: true),
                    userid = table.Column<Guid>(type: "uuid", nullable: true),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    tenantname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    clientid = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    correlationid = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    clientipaddress = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    browserinfo = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpsecuritylogs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abpsettingdefinitions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    displayname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    defaultvalue = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    isvisibletoclients = table.Column<bool>(type: "boolean", nullable: false),
                    providers = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    isinherited = table.Column<bool>(type: "boolean", nullable: false),
                    isencrypted = table.Column<bool>(type: "boolean", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpsettingdefinitions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abpsettings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    value = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    providername = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    providerkey = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpsettings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abptenants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    entityversion = table.Column<int>(type: "integer", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true),
                    lastmodificationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastmodifierid = table.Column<Guid>(type: "uuid", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    deleterid = table.Column<Guid>(type: "uuid", nullable: true),
                    deletiontime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abptenants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abpuserdelegations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    sourceuserid = table.Column<Guid>(type: "uuid", nullable: false),
                    targetuserid = table.Column<Guid>(type: "uuid", nullable: false),
                    starttime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    endtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpuserdelegations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abpusers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    normalizedusername = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    surname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    normalizedemail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    emailconfirmed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    passwordhash = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    securitystamp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    isexternal = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    phonenumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    lockoutend = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    accessfailedcount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    shouldchangepasswordonnextlogin = table.Column<bool>(type: "boolean", nullable: false),
                    entityversion = table.Column<int>(type: "integer", nullable: false),
                    lastpasswordchangetime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true),
                    lastmodificationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastmodifierid = table.Column<Guid>(type: "uuid", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    deleterid = table.Column<Guid>(type: "uuid", nullable: true),
                    deletiontime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "basicdictype",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(90)", maxLength: 90, nullable: false),
                    code = table.Column<string>(type: "character varying(90)", maxLength: 90, nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true),
                    lastmodificationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastmodifierid = table.Column<Guid>(type: "uuid", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    deleterid = table.Column<Guid>(type: "uuid", nullable: true),
                    deletiontime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_basicdictype", x => x.id);
                },
                comment: "字典类型");

            migrationBuilder.CreateTable(
                name: "identityserverapiresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    displayname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    allowedaccesstokensigningalgorithms = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    showindiscoverydocument = table.Column<bool>(type: "boolean", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true),
                    lastmodificationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastmodifierid = table.Column<Guid>(type: "uuid", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    deleterid = table.Column<Guid>(type: "uuid", nullable: true),
                    deletiontime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverapiresources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identityserverapiscopes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    displayname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    required = table.Column<bool>(type: "boolean", nullable: false),
                    emphasize = table.Column<bool>(type: "boolean", nullable: false),
                    showindiscoverydocument = table.Column<bool>(type: "boolean", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true),
                    lastmodificationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastmodifierid = table.Column<Guid>(type: "uuid", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    deleterid = table.Column<Guid>(type: "uuid", nullable: true),
                    deletiontime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverapiscopes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identityserverclients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    clientid = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    clientname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    clienturi = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    logouri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    protocoltype = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    requireclientsecret = table.Column<bool>(type: "boolean", nullable: false),
                    requireconsent = table.Column<bool>(type: "boolean", nullable: false),
                    allowrememberconsent = table.Column<bool>(type: "boolean", nullable: false),
                    alwaysincludeuserclaimsinidtoken = table.Column<bool>(type: "boolean", nullable: false),
                    requirepkce = table.Column<bool>(type: "boolean", nullable: false),
                    allowplaintextpkce = table.Column<bool>(type: "boolean", nullable: false),
                    requirerequestobject = table.Column<bool>(type: "boolean", nullable: false),
                    allowaccesstokensviabrowser = table.Column<bool>(type: "boolean", nullable: false),
                    frontchannellogouturi = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    frontchannellogoutsessionrequired = table.Column<bool>(type: "boolean", nullable: false),
                    backchannellogouturi = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    backchannellogoutsessionrequired = table.Column<bool>(type: "boolean", nullable: false),
                    allowofflineaccess = table.Column<bool>(type: "boolean", nullable: false),
                    identitytokenlifetime = table.Column<int>(type: "integer", nullable: false),
                    allowedidentitytokensigningalgorithms = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    accesstokenlifetime = table.Column<int>(type: "integer", nullable: false),
                    authorizationcodelifetime = table.Column<int>(type: "integer", nullable: false),
                    consentlifetime = table.Column<int>(type: "integer", nullable: true),
                    absoluterefreshtokenlifetime = table.Column<int>(type: "integer", nullable: false),
                    slidingrefreshtokenlifetime = table.Column<int>(type: "integer", nullable: false),
                    refreshtokenusage = table.Column<int>(type: "integer", nullable: false),
                    updateaccesstokenclaimsonrefresh = table.Column<bool>(type: "boolean", nullable: false),
                    refreshtokenexpiration = table.Column<int>(type: "integer", nullable: false),
                    accesstokentype = table.Column<int>(type: "integer", nullable: false),
                    enablelocallogin = table.Column<bool>(type: "boolean", nullable: false),
                    includejwtid = table.Column<bool>(type: "boolean", nullable: false),
                    alwayssendclientclaims = table.Column<bool>(type: "boolean", nullable: false),
                    clientclaimsprefix = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    pairwisesubjectsalt = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    userssolifetime = table.Column<int>(type: "integer", nullable: true),
                    usercodetype = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    devicecodelifetime = table.Column<int>(type: "integer", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true),
                    lastmodificationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastmodifierid = table.Column<Guid>(type: "uuid", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    deleterid = table.Column<Guid>(type: "uuid", nullable: true),
                    deletiontime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverclients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identityserverdeviceflowcodes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    devicecode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    usercode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    subjectid = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    sessionid = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    clientid = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverdeviceflowcodes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identityserveridentityresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    displayname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    required = table.Column<bool>(type: "boolean", nullable: false),
                    emphasize = table.Column<bool>(type: "boolean", nullable: false),
                    showindiscoverydocument = table.Column<bool>(type: "boolean", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true),
                    lastmodificationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastmodifierid = table.Column<Guid>(type: "uuid", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    deleterid = table.Column<Guid>(type: "uuid", nullable: true),
                    deletiontime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserveridentityresources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identityserverpersistedgrants",
                columns: table => new
                {
                    key = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    subjectid = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    sessionid = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    clientid = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    consumedtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverpersistedgrants", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "abpauditlogactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    auditlogid = table.Column<Guid>(type: "uuid", nullable: false),
                    servicename = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    methodname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    parameters = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    executiontime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    executionduration = table.Column<int>(type: "integer", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpauditlogactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_abpauditlogactions_abpauditlogs_auditlogid",
                        column: x => x.auditlogid,
                        principalTable: "abpauditlogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abpentitychanges",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    auditlogid = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    changetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    changetype = table.Column<byte>(type: "smallint", nullable: false),
                    entitytenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    entityid = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    entitytypefullname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpentitychanges", x => x.id);
                    table.ForeignKey(
                        name: "fk_abpentitychanges_abpauditlogs_auditlogid",
                        column: x => x.auditlogid,
                        principalTable: "abpauditlogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abporganizationunitroles",
                columns: table => new
                {
                    roleid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationunitid = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abporganizationunitroles", x => new { x.organizationunitid, x.roleid });
                    table.ForeignKey(
                        name: "fk_abporganizationunitroles_abporganizationunits_organizationu~",
                        column: x => x.organizationunitid,
                        principalTable: "abporganizationunits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abporganizationunitroles_abproles_roleid",
                        column: x => x.roleid,
                        principalTable: "abproles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abproleclaims",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    claimtype = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    claimvalue = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abproleclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_abproleclaims_abproles_roleid",
                        column: x => x.roleid,
                        principalTable: "abproles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abptenantconnectionstrings",
                columns: table => new
                {
                    tenantid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    value = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abptenantconnectionstrings", x => new { x.tenantid, x.name });
                    table.ForeignKey(
                        name: "fk_abptenantconnectionstrings_abptenants_tenantid",
                        column: x => x.tenantid,
                        principalTable: "abptenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abpuserclaims",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    claimtype = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    claimvalue = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpuserclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_abpuserclaims_abpusers_userid",
                        column: x => x.userid,
                        principalTable: "abpusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abpuserlogins",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    loginprovider = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    providerkey = table.Column<string>(type: "character varying(196)", maxLength: 196, nullable: false),
                    providerdisplayname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpuserlogins", x => new { x.userid, x.loginprovider });
                    table.ForeignKey(
                        name: "fk_abpuserlogins_abpusers_userid",
                        column: x => x.userid,
                        principalTable: "abpusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abpuserorganizationunits",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationunitid = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpuserorganizationunits", x => new { x.organizationunitid, x.userid });
                    table.ForeignKey(
                        name: "fk_abpuserorganizationunits_abporganizationunits_organizationu~",
                        column: x => x.organizationunitid,
                        principalTable: "abporganizationunits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abpuserorganizationunits_abpusers_userid",
                        column: x => x.userid,
                        principalTable: "abpusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abpuserroles",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpuserroles", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "fk_abpuserroles_abproles_roleid",
                        column: x => x.roleid,
                        principalTable: "abproles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abpuserroles_abpusers_userid",
                        column: x => x.userid,
                        principalTable: "abpusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abpusertokens",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    loginprovider = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpusertokens", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "fk_abpusertokens_abpusers_userid",
                        column: x => x.userid,
                        principalTable: "abpusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "basicdicinfo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    dictypeid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(90)", maxLength: 90, nullable: false),
                    value = table.Column<string>(type: "character varying(90)", maxLength: 90, nullable: false),
                    sort = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    extraproperties = table.Column<string>(type: "text", nullable: false),
                    concurrencystamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    creationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatorid = table.Column<Guid>(type: "uuid", nullable: true),
                    lastmodificationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastmodifierid = table.Column<Guid>(type: "uuid", nullable: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    deleterid = table.Column<Guid>(type: "uuid", nullable: true),
                    deletiontime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_basicdicinfo", x => x.id);
                    table.ForeignKey(
                        name: "fk_basicdicinfo_basicdictype_dictypeid",
                        column: x => x.dictypeid,
                        principalTable: "basicdictype",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "数据字典");

            migrationBuilder.CreateTable(
                name: "identityserverapiresourceclaims",
                columns: table => new
                {
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    apiresourceid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverapiresourceclaims", x => new { x.apiresourceid, x.type });
                    table.ForeignKey(
                        name: "fk_identityserverapiresourceclaims_identityserverapiresources_~",
                        column: x => x.apiresourceid,
                        principalTable: "identityserverapiresources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverapiresourceproperties",
                columns: table => new
                {
                    apiresourceid = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverapiresourceproperties", x => new { x.apiresourceid, x.key, x.value });
                    table.ForeignKey(
                        name: "fk_identityserverapiresourceproperties_identityserverapiresour~",
                        column: x => x.apiresourceid,
                        principalTable: "identityserverapiresources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverapiresourcescopes",
                columns: table => new
                {
                    apiresourceid = table.Column<Guid>(type: "uuid", nullable: false),
                    scope = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverapiresourcescopes", x => new { x.apiresourceid, x.scope });
                    table.ForeignKey(
                        name: "fk_identityserverapiresourcescopes_identityserverapiresources_~",
                        column: x => x.apiresourceid,
                        principalTable: "identityserverapiresources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverapiresourcesecrets",
                columns: table => new
                {
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    apiresourceid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverapiresourcesecrets", x => new { x.apiresourceid, x.type, x.value });
                    table.ForeignKey(
                        name: "fk_identityserverapiresourcesecrets_identityserverapiresources~",
                        column: x => x.apiresourceid,
                        principalTable: "identityserverapiresources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverapiscopeclaims",
                columns: table => new
                {
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    apiscopeid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverapiscopeclaims", x => new { x.apiscopeid, x.type });
                    table.ForeignKey(
                        name: "fk_identityserverapiscopeclaims_identityserverapiscopes_apisco~",
                        column: x => x.apiscopeid,
                        principalTable: "identityserverapiscopes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverapiscopeproperties",
                columns: table => new
                {
                    apiscopeid = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverapiscopeproperties", x => new { x.apiscopeid, x.key, x.value });
                    table.ForeignKey(
                        name: "fk_identityserverapiscopeproperties_identityserverapiscopes_ap~",
                        column: x => x.apiscopeid,
                        principalTable: "identityserverapiscopes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverclientclaims",
                columns: table => new
                {
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverclientclaims", x => new { x.clientid, x.type, x.value });
                    table.ForeignKey(
                        name: "fk_identityserverclientclaims_identityserverclients_clientid",
                        column: x => x.clientid,
                        principalTable: "identityserverclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverclientcorsorigins",
                columns: table => new
                {
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    origin = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverclientcorsorigins", x => new { x.clientid, x.origin });
                    table.ForeignKey(
                        name: "fk_identityserverclientcorsorigins_identityserverclients_clien~",
                        column: x => x.clientid,
                        principalTable: "identityserverclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverclientgranttypes",
                columns: table => new
                {
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    granttype = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverclientgranttypes", x => new { x.clientid, x.granttype });
                    table.ForeignKey(
                        name: "fk_identityserverclientgranttypes_identityserverclients_client~",
                        column: x => x.clientid,
                        principalTable: "identityserverclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverclientidprestrictions",
                columns: table => new
                {
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    provider = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverclientidprestrictions", x => new { x.clientid, x.provider });
                    table.ForeignKey(
                        name: "fk_identityserverclientidprestrictions_identityserverclients_c~",
                        column: x => x.clientid,
                        principalTable: "identityserverclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverclientpostlogoutredirecturis",
                columns: table => new
                {
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    postlogoutredirecturi = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverclientpostlogoutredirecturis", x => new { x.clientid, x.postlogoutredirecturi });
                    table.ForeignKey(
                        name: "fk_identityserverclientpostlogoutredirecturis_identityservercl~",
                        column: x => x.clientid,
                        principalTable: "identityserverclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverclientproperties",
                columns: table => new
                {
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverclientproperties", x => new { x.clientid, x.key, x.value });
                    table.ForeignKey(
                        name: "fk_identityserverclientproperties_identityserverclients_client~",
                        column: x => x.clientid,
                        principalTable: "identityserverclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverclientredirecturis",
                columns: table => new
                {
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    redirecturi = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverclientredirecturis", x => new { x.clientid, x.redirecturi });
                    table.ForeignKey(
                        name: "fk_identityserverclientredirecturis_identityserverclients_clie~",
                        column: x => x.clientid,
                        principalTable: "identityserverclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverclientscopes",
                columns: table => new
                {
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    scope = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverclientscopes", x => new { x.clientid, x.scope });
                    table.ForeignKey(
                        name: "fk_identityserverclientscopes_identityserverclients_clientid",
                        column: x => x.clientid,
                        principalTable: "identityserverclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserverclientsecrets",
                columns: table => new
                {
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserverclientsecrets", x => new { x.clientid, x.type, x.value });
                    table.ForeignKey(
                        name: "fk_identityserverclientsecrets_identityserverclients_clientid",
                        column: x => x.clientid,
                        principalTable: "identityserverclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserveridentityresourceclaims",
                columns: table => new
                {
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    identityresourceid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserveridentityresourceclaims", x => new { x.identityresourceid, x.type });
                    table.ForeignKey(
                        name: "fk_identityserveridentityresourceclaims_identityserveridentity~",
                        column: x => x.identityresourceid,
                        principalTable: "identityserveridentityresources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityserveridentityresourceproperties",
                columns: table => new
                {
                    identityresourceid = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityserveridentityresourceproperties", x => new { x.identityresourceid, x.key, x.value });
                    table.ForeignKey(
                        name: "fk_identityserveridentityresourceproperties_identityserveriden~",
                        column: x => x.identityresourceid,
                        principalTable: "identityserveridentityresources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abpentitypropertychanges",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    entitychangeid = table.Column<Guid>(type: "uuid", nullable: false),
                    newvalue = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    originalvalue = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    propertyname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    propertytypefullname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abpentitypropertychanges", x => x.id);
                    table.ForeignKey(
                        name: "fk_abpentitypropertychanges_abpentitychanges_entitychangeid",
                        column: x => x.entitychangeid,
                        principalTable: "abpentitychanges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_abpauditlogactions_auditlogid",
                table: "abpauditlogactions",
                column: "auditlogid");

            migrationBuilder.CreateIndex(
                name: "IX_abpauditlogactions_tenantid_servicename_methodname_executio~",
                table: "abpauditlogactions",
                columns: new[] { "tenantid", "servicename", "methodname", "executiontime" });

            migrationBuilder.CreateIndex(
                name: "IX_abpauditlogs_tenantid_executiontime",
                table: "abpauditlogs",
                columns: new[] { "tenantid", "executiontime" });

            migrationBuilder.CreateIndex(
                name: "IX_abpauditlogs_tenantid_userid_executiontime",
                table: "abpauditlogs",
                columns: new[] { "tenantid", "userid", "executiontime" });

            migrationBuilder.CreateIndex(
                name: "IX_abpbackgroundjobs_isabandoned_nexttrytime",
                table: "abpbackgroundjobs",
                columns: new[] { "isabandoned", "nexttrytime" });

            migrationBuilder.CreateIndex(
                name: "IX_abpentitychanges_auditlogid",
                table: "abpentitychanges",
                column: "auditlogid");

            migrationBuilder.CreateIndex(
                name: "IX_abpentitychanges_tenantid_entitytypefullname_entityid",
                table: "abpentitychanges",
                columns: new[] { "tenantid", "entitytypefullname", "entityid" });

            migrationBuilder.CreateIndex(
                name: "IX_abpentitypropertychanges_entitychangeid",
                table: "abpentitypropertychanges",
                column: "entitychangeid");

            migrationBuilder.CreateIndex(
                name: "IX_abpfeaturegroups_name",
                table: "abpfeaturegroups",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abpfeatures_groupname",
                table: "abpfeatures",
                column: "groupname");

            migrationBuilder.CreateIndex(
                name: "IX_abpfeatures_name",
                table: "abpfeatures",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abpfeaturevalues_name_providername_providerkey",
                table: "abpfeaturevalues",
                columns: new[] { "name", "providername", "providerkey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abplinkusers_sourceuserid_sourcetenantid_targetuserid_targe~",
                table: "abplinkusers",
                columns: new[] { "sourceuserid", "sourcetenantid", "targetuserid", "targettenantid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abporganizationunitroles_roleid_organizationunitid",
                table: "abporganizationunitroles",
                columns: new[] { "roleid", "organizationunitid" });

            migrationBuilder.CreateIndex(
                name: "IX_abporganizationunits_code",
                table: "abporganizationunits",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_abporganizationunits_parentid",
                table: "abporganizationunits",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "IX_abppermissiongrants_tenantid_name_providername_providerkey",
                table: "abppermissiongrants",
                columns: new[] { "tenantid", "name", "providername", "providerkey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abppermissiongroups_name",
                table: "abppermissiongroups",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abppermissions_groupname",
                table: "abppermissions",
                column: "groupname");

            migrationBuilder.CreateIndex(
                name: "IX_abppermissions_name",
                table: "abppermissions",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abproleclaims_roleid",
                table: "abproleclaims",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_abproles_normalizedname",
                table: "abproles",
                column: "normalizedname");

            migrationBuilder.CreateIndex(
                name: "IX_abpsecuritylogs_tenantid_action",
                table: "abpsecuritylogs",
                columns: new[] { "tenantid", "action" });

            migrationBuilder.CreateIndex(
                name: "IX_abpsecuritylogs_tenantid_applicationname",
                table: "abpsecuritylogs",
                columns: new[] { "tenantid", "applicationname" });

            migrationBuilder.CreateIndex(
                name: "IX_abpsecuritylogs_tenantid_identity",
                table: "abpsecuritylogs",
                columns: new[] { "tenantid", "identity" });

            migrationBuilder.CreateIndex(
                name: "IX_abpsecuritylogs_tenantid_userid",
                table: "abpsecuritylogs",
                columns: new[] { "tenantid", "userid" });

            migrationBuilder.CreateIndex(
                name: "IX_abpsettingdefinitions_name",
                table: "abpsettingdefinitions",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abpsettings_name_providername_providerkey",
                table: "abpsettings",
                columns: new[] { "name", "providername", "providerkey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abptenants_name",
                table: "abptenants",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_abpuserclaims_userid",
                table: "abpuserclaims",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_abpuserlogins_loginprovider_providerkey",
                table: "abpuserlogins",
                columns: new[] { "loginprovider", "providerkey" });

            migrationBuilder.CreateIndex(
                name: "IX_abpuserorganizationunits_userid_organizationunitid",
                table: "abpuserorganizationunits",
                columns: new[] { "userid", "organizationunitid" });

            migrationBuilder.CreateIndex(
                name: "IX_abpuserroles_roleid_userid",
                table: "abpuserroles",
                columns: new[] { "roleid", "userid" });

            migrationBuilder.CreateIndex(
                name: "IX_abpusers_email",
                table: "abpusers",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_abpusers_normalizedemail",
                table: "abpusers",
                column: "normalizedemail");

            migrationBuilder.CreateIndex(
                name: "IX_abpusers_normalizedusername",
                table: "abpusers",
                column: "normalizedusername");

            migrationBuilder.CreateIndex(
                name: "IX_abpusers_username",
                table: "abpusers",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_basicdicinfo_dictypeid",
                table: "basicdicinfo",
                column: "dictypeid");

            migrationBuilder.CreateIndex(
                name: "IX_identityserverclients_clientid",
                table: "identityserverclients",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_identityserverdeviceflowcodes_devicecode",
                table: "identityserverdeviceflowcodes",
                column: "devicecode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_identityserverdeviceflowcodes_expiration",
                table: "identityserverdeviceflowcodes",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "IX_identityserverdeviceflowcodes_usercode",
                table: "identityserverdeviceflowcodes",
                column: "usercode");

            migrationBuilder.CreateIndex(
                name: "IX_identityserverpersistedgrants_expiration",
                table: "identityserverpersistedgrants",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "IX_identityserverpersistedgrants_subjectid_clientid_type",
                table: "identityserverpersistedgrants",
                columns: new[] { "subjectid", "clientid", "type" });

            migrationBuilder.CreateIndex(
                name: "IX_identityserverpersistedgrants_subjectid_sessionid_type",
                table: "identityserverpersistedgrants",
                columns: new[] { "subjectid", "sessionid", "type" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abpauditlogactions");

            migrationBuilder.DropTable(
                name: "abpbackgroundjobs");

            migrationBuilder.DropTable(
                name: "abpclaimtypes");

            migrationBuilder.DropTable(
                name: "abpentitypropertychanges");

            migrationBuilder.DropTable(
                name: "abpfeaturegroups");

            migrationBuilder.DropTable(
                name: "abpfeatures");

            migrationBuilder.DropTable(
                name: "abpfeaturevalues");

            migrationBuilder.DropTable(
                name: "abplinkusers");

            migrationBuilder.DropTable(
                name: "abporganizationunitroles");

            migrationBuilder.DropTable(
                name: "abppermissiongrants");

            migrationBuilder.DropTable(
                name: "abppermissiongroups");

            migrationBuilder.DropTable(
                name: "abppermissions");

            migrationBuilder.DropTable(
                name: "abproleclaims");

            migrationBuilder.DropTable(
                name: "abpsecuritylogs");

            migrationBuilder.DropTable(
                name: "abpsettingdefinitions");

            migrationBuilder.DropTable(
                name: "abpsettings");

            migrationBuilder.DropTable(
                name: "abptenantconnectionstrings");

            migrationBuilder.DropTable(
                name: "abpuserclaims");

            migrationBuilder.DropTable(
                name: "abpuserdelegations");

            migrationBuilder.DropTable(
                name: "abpuserlogins");

            migrationBuilder.DropTable(
                name: "abpuserorganizationunits");

            migrationBuilder.DropTable(
                name: "abpuserroles");

            migrationBuilder.DropTable(
                name: "abpusertokens");

            migrationBuilder.DropTable(
                name: "basicdicinfo");

            migrationBuilder.DropTable(
                name: "identityserverapiresourceclaims");

            migrationBuilder.DropTable(
                name: "identityserverapiresourceproperties");

            migrationBuilder.DropTable(
                name: "identityserverapiresourcescopes");

            migrationBuilder.DropTable(
                name: "identityserverapiresourcesecrets");

            migrationBuilder.DropTable(
                name: "identityserverapiscopeclaims");

            migrationBuilder.DropTable(
                name: "identityserverapiscopeproperties");

            migrationBuilder.DropTable(
                name: "identityserverclientclaims");

            migrationBuilder.DropTable(
                name: "identityserverclientcorsorigins");

            migrationBuilder.DropTable(
                name: "identityserverclientgranttypes");

            migrationBuilder.DropTable(
                name: "identityserverclientidprestrictions");

            migrationBuilder.DropTable(
                name: "identityserverclientpostlogoutredirecturis");

            migrationBuilder.DropTable(
                name: "identityserverclientproperties");

            migrationBuilder.DropTable(
                name: "identityserverclientredirecturis");

            migrationBuilder.DropTable(
                name: "identityserverclientscopes");

            migrationBuilder.DropTable(
                name: "identityserverclientsecrets");

            migrationBuilder.DropTable(
                name: "identityserverdeviceflowcodes");

            migrationBuilder.DropTable(
                name: "identityserveridentityresourceclaims");

            migrationBuilder.DropTable(
                name: "identityserveridentityresourceproperties");

            migrationBuilder.DropTable(
                name: "identityserverpersistedgrants");

            migrationBuilder.DropTable(
                name: "abpentitychanges");

            migrationBuilder.DropTable(
                name: "abptenants");

            migrationBuilder.DropTable(
                name: "abporganizationunits");

            migrationBuilder.DropTable(
                name: "abproles");

            migrationBuilder.DropTable(
                name: "abpusers");

            migrationBuilder.DropTable(
                name: "basicdictype");

            migrationBuilder.DropTable(
                name: "identityserverapiresources");

            migrationBuilder.DropTable(
                name: "identityserverapiscopes");

            migrationBuilder.DropTable(
                name: "identityserverclients");

            migrationBuilder.DropTable(
                name: "identityserveridentityresources");

            migrationBuilder.DropTable(
                name: "abpauditlogs");
        }
    }
}
