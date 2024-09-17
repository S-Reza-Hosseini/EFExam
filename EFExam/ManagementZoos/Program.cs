using residential_complex.Io;
using residential_complex.Io.Menues;
using Zoo.Persistence;

var consoleUi = new ConsoleUi();
var dbContext = new EFDataContext();

var mainMenu = new MainMenu(dbContext, consoleUi);
mainMenu.Show();