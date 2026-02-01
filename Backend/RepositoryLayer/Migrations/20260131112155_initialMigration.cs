using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DynamicSignalForms");

            migrationBuilder.CreateTable(
                name: "SignalForm",
                schema: "DynamicSignalForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FormType = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CssClasses = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignalFormField",
                schema: "DynamicSignalForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InputType = table.Column<int>(type: "integer", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Property = table.Column<string>(type: "text", nullable: false),
                    PropertyType = table.Column<int>(type: "integer", nullable: false),
                    InitialValue = table.Column<string>(type: "text", nullable: false),
                    CssClasses = table.Column<string>(type: "text", nullable: false),
                    SignalFormId = table.Column<int>(type: "integer", nullable: true),
                    FormArrayId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalFormField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignalFormField_SignalForm_SignalFormId",
                        column: x => x.SignalFormId,
                        principalSchema: "DynamicSignalForms",
                        principalTable: "SignalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignalFormAdditionalData",
                schema: "DynamicSignalForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Attribute = table.Column<string>(type: "text", nullable: false),
                    AttributeType = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    SignalFormFieldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalFormAdditionalData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignalFormAdditionalData_SignalFormField_SignalFormFieldId",
                        column: x => x.SignalFormFieldId,
                        principalSchema: "DynamicSignalForms",
                        principalTable: "SignalFormField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignalFormOption",
                schema: "DynamicSignalForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    TypeOfValue = table.Column<int>(type: "integer", nullable: false),
                    SignalFormFieldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalFormOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignalFormOption_SignalFormField_SignalFormFieldId",
                        column: x => x.SignalFormFieldId,
                        principalSchema: "DynamicSignalForms",
                        principalTable: "SignalFormField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignalFormValidation",
                schema: "DynamicSignalForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Validation = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    SignalFormFieldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalFormValidation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignalFormValidation_SignalFormField_SignalFormFieldId",
                        column: x => x.SignalFormFieldId,
                        principalSchema: "DynamicSignalForms",
                        principalTable: "SignalFormField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "DynamicSignalForms",
                table: "SignalForm",
                columns: new[] { "Id", "CssClasses", "FormType", "Title" },
                values: new object[,]
                {
                    { 1, "column w-50 p-1", 1, "The first form (basic)" },
                    { 2, "column w-50 p-1", 1, "The second form (callbacks)" },
                    { 3, "column w-50 p-1", 1, "The third form (start- and enddate)" },
                    { 4, "column w-50 p-1", 1, "The fourth form (autocomplete)" },
                    { 5, "column w-50 p-1", 1, "The fifth form (number inputs)" },
                    { 6, "column w-50 p-1", 1, "The sixth form (single select)." },
                    { 7, "column w-50 p-1", 1, "The seventh form (multiple select)." },
                    { 8, "column w-50 p-1", 1, "The eighth form (radiobuttons)." },
                    { 9, "column w-50 p-1", 1, "The ninth form (todo-list parent)." },
                    { 10, "row w-50", 2, "The tenth form (form array)." }
                });

            migrationBuilder.InsertData(
                schema: "DynamicSignalForms",
                table: "SignalFormField",
                columns: new[] { "Id", "CssClasses", "FormArrayId", "InitialValue", "InputType", "Label", "Property", "PropertyType", "SignalFormId" },
                values: new object[,]
                {
                    { 1, "column", null, "", 1, "Firstname", "firstname", 1, 1 },
                    { 2, "column", null, "", 1, "Lastname", "lastname", 1, 1 },
                    { 3, "column", null, "18", 5, "Age", "age", 2, 1 },
                    { 4, "column", null, "", 15, "Information about Person", "information", 1, 1 },
                    { 5, "column", null, "", 2, "Firstname", "firstname", 1, 2 },
                    { 6, "column", null, "", 2, "Lastname", "lastname", 1, 2 },
                    { 7, "column", null, "18", 6, "Age", "age", 2, 2 },
                    { 8, "column", null, "", 16, "Information about Person", "information", 1, 2 },
                    { 9, "column", null, "", 9, "Startdate (from today until 30 days)", "startdate", 10, 3 },
                    { 10, "column", null, "", 9, "Enddate (from today until 30 days)", "enddate", 10, 3 },
                    { 11, "column", null, "", 3, "Favorite Fruit", "fruit", 1, 4 },
                    { 12, "column", null, "", 4, "Favorite Car", "car", 1, 4 },
                    { 13, "column", null, "10.00", 7, "Your bid for second hand book (10.00 - 100.00)", "bid", 2, 5 },
                    { 14, "column", null, "16.00", 8, "Enter value between -25.00 and 25.00", "valuebetween", 2, 5 },
                    { 15, "column", null, "25", 5, "Random Positive Number (10 - 75)", "randompositivenumber", 2, 5 },
                    { 16, "column", null, "-25", 6, "Random Negative Number (from -10 to -75)", "randomnegativenumber", 2, 5 },
                    { 17, "column", null, "Saskia", 11, "Select Girl Name", "selectgirlname", 1, 6 },
                    { 18, "column", null, "White", 12, "Select Color", "selectcolor", 1, 6 },
                    { 19, "column", null, "Natasha, Jasmine", 13, "Select Girl Names", "select_girl_names_multi", 4, 7 },
                    { 20, "column", null, "Hamster, Rabbit", 14, "Select Animals", "select_animals_multi", 4, 7 },
                    { 21, "column", null, "1", 17, "Select Option", "select_option", 2, 8 },
                    { 22, "column", null, "0", 18, "Select Choice", "select_choice", 2, 8 },
                    { 23, "column", null, "false", 19, "I agree to the general conditions", "general_conditions", 3, 8 },
                    { 24, "column", null, "true", 20, "I agree with the service agreement (default: true)", "service_agreement", 3, 8 },
                    { 25, "column mb-1", null, "false", 21, "Confirm agreements", "confirm_agreements", 3, 8 },
                    { 26, "column mb-1", null, "true", 22, "I read and understand all agreements", "read_agreements", 3, 8 },
                    { 27, "column", null, "", 1, "My Todo List", "title", 1, 9 },
                    { 28, "", 10, "", 23, "FORM_ARRAY", "todos", 9, 9 },
                    { 29, "column", null, "", 1, "Task", "task", 1, 10 },
                    { 30, "column pt-1 ms-1", null, "false", 21, "Completed?", "completed", 3, 10 }
                });

            migrationBuilder.InsertData(
                schema: "DynamicSignalForms",
                table: "SignalFormAdditionalData",
                columns: new[] { "Id", "Attribute", "AttributeType", "SignalFormFieldId", "Value" },
                values: new object[,]
                {
                    { 1, "cols", 2, 4, "30" },
                    { 2, "rows", 2, 4, "5" },
                    { 3, "cols", 2, 8, "30" },
                    { 4, "rows", 2, 8, "5" }
                });

            migrationBuilder.InsertData(
                schema: "DynamicSignalForms",
                table: "SignalFormOption",
                columns: new[] { "Id", "Label", "SignalFormFieldId", "TypeOfValue", "Value" },
                values: new object[,]
                {
                    { 1, "ananas", 11, 0, "" },
                    { 2, "apple", 11, 0, "" },
                    { 3, "banana", 11, 0, "" },
                    { 4, "black berry", 11, 0, "" },
                    { 5, "peach", 11, 0, "" },
                    { 6, "pear", 11, 0, "" },
                    { 7, "strawberry", 11, 0, "" },
                    { 8, "Alfa Romeo", 12, 0, "" },
                    { 9, "Batmobile", 12, 0, "" },
                    { 10, "Ferrari", 12, 0, "" },
                    { 11, "Lada", 12, 0, "" },
                    { 12, "Lamborghini", 12, 0, "" },
                    { 13, "Mercedes", 12, 0, "" },
                    { 14, "Porsche", 12, 0, "" },
                    { 15, "Saskia", 17, 0, "" },
                    { 16, "Matilda", 17, 0, "" },
                    { 17, "Juliette", 17, 0, "" },
                    { 18, "Caroline", 17, 0, "" },
                    { 19, "Victoria", 17, 0, "" },
                    { 20, "Abigaïl", 17, 0, "" },
                    { 21, "Caitlin", 17, 0, "" },
                    { 22, "Black", 18, 0, "" },
                    { 23, "Blue", 18, 0, "" },
                    { 24, "Green", 18, 0, "" },
                    { 25, "Red", 18, 0, "" },
                    { 26, "Turquoise", 18, 0, "" },
                    { 27, "Yellow", 18, 0, "" },
                    { 28, "White", 18, 0, "" },
                    { 29, "Dorothy", 19, 0, "" },
                    { 30, "Jasmine", 19, 0, "" },
                    { 31, "Lydia", 19, 0, "" },
                    { 32, "Natasha", 19, 0, "" },
                    { 33, "Savannah", 19, 0, "" },
                    { 34, "Serana", 19, 0, "" },
                    { 35, "Triss", 19, 0, "" },
                    { 36, "Cat", 20, 0, "" },
                    { 37, "Dog", 20, 0, "" },
                    { 38, "Ferret", 20, 0, "" },
                    { 39, "Goldfish", 20, 0, "" },
                    { 40, "Guinea pig", 20, 0, "" },
                    { 41, "Hamster", 20, 0, "" },
                    { 42, "Horse", 20, 0, "" },
                    { 43, "Lizard", 20, 0, "" },
                    { 44, "Mouse", 20, 0, "" },
                    { 45, "Parrot", 20, 0, "" },
                    { 46, "Rabbit", 20, 0, "" },
                    { 47, "Sheep", 20, 0, "" },
                    { 48, "Turtle", 20, 0, "" },
                    { 49, "Option 1", 21, 2, "1" },
                    { 50, "Option 2", 21, 2, "2" },
                    { 51, "Option 3", 21, 2, "3" },
                    { 52, "Yes, I want to receive newsletters", 22, 2, "1" },
                    { 53, "Yes, I want to receive alerts", 22, 2, "2" },
                    { 54, "Yes, I want to receive newsletters and alerts", 22, 2, "3" },
                    { 55, "No thanks, I don't want to receive newsletters and alerts", 22, 2, "0" }
                });

            migrationBuilder.InsertData(
                schema: "DynamicSignalForms",
                table: "SignalFormValidation",
                columns: new[] { "Id", "SignalFormFieldId", "Validation", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, "" },
                    { 2, 2, 1, "" },
                    { 3, 3, 1, "" },
                    { 4, 3, 4, "18" },
                    { 5, 3, 5, "65" },
                    { 6, 4, 1, "" },
                    { 7, 4, 3, "250" },
                    { 8, 5, 1, "" },
                    { 9, 6, 1, "" },
                    { 10, 7, 1, "" },
                    { 11, 7, 4, "18" },
                    { 12, 7, 5, "65" },
                    { 13, 8, 1, "" },
                    { 14, 8, 3, "250" },
                    { 15, 9, 1, "" },
                    { 16, 9, 9, "0" },
                    { 17, 9, 13, "30" },
                    { 18, 9, 17, "enddate" },
                    { 19, 9, 18, "enddate" },
                    { 20, 10, 1, "" },
                    { 21, 10, 9, "0" },
                    { 22, 10, 13, "30" },
                    { 23, 10, 17, "startdate" },
                    { 24, 10, 19, "startdate" },
                    { 25, 11, 1, "" },
                    { 26, 12, 1, "" },
                    { 27, 13, 1, "" },
                    { 28, 13, 7, "10.00" },
                    { 29, 13, 8, "100.00" },
                    { 30, 14, 1, "" },
                    { 31, 14, 7, "-25.00" },
                    { 32, 14, 8, "25.00" },
                    { 33, 15, 1, "" },
                    { 34, 15, 4, "10" },
                    { 35, 15, 5, "75" },
                    { 36, 16, 1, "" },
                    { 37, 16, 4, "-75" },
                    { 38, 16, 5, "-10" },
                    { 39, 17, 1, "" },
                    { 40, 18, 1, "" },
                    { 41, 19, 1, "" },
                    { 42, 20, 1, "" },
                    { 43, 21, 1, "" },
                    { 44, 22, 1, "" },
                    { 45, 23, 1, "" },
                    { 46, 24, 1, "" },
                    { 47, 25, 1, "" },
                    { 48, 26, 1, "" },
                    { 49, 27, 1, "" },
                    { 50, 29, 1, "" },
                    { 51, 30, 1, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SignalFormAdditionalData_SignalFormFieldId",
                schema: "DynamicSignalForms",
                table: "SignalFormAdditionalData",
                column: "SignalFormFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SignalFormField_SignalFormId",
                schema: "DynamicSignalForms",
                table: "SignalFormField",
                column: "SignalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_SignalFormOption_SignalFormFieldId",
                schema: "DynamicSignalForms",
                table: "SignalFormOption",
                column: "SignalFormFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SignalFormValidation_SignalFormFieldId",
                schema: "DynamicSignalForms",
                table: "SignalFormValidation",
                column: "SignalFormFieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignalFormAdditionalData",
                schema: "DynamicSignalForms");

            migrationBuilder.DropTable(
                name: "SignalFormOption",
                schema: "DynamicSignalForms");

            migrationBuilder.DropTable(
                name: "SignalFormValidation",
                schema: "DynamicSignalForms");

            migrationBuilder.DropTable(
                name: "SignalFormField",
                schema: "DynamicSignalForms");

            migrationBuilder.DropTable(
                name: "SignalForm",
                schema: "DynamicSignalForms");
        }
    }
}
