using MenuBuddy;
using Microsoft.Xna.Framework;

namespace MenuBuddySample
{
	/// <summary>
	/// The main menu screen is the first thing displayed when the game starts up.
	/// </summary>
	internal class MainMenuScreen : MenuScreen, IMainMenu
	{
		#region Initialization

		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public MainMenuScreen()
			: base("Main Menu")
		{
		}

		#endregion //Initialization

		#region Methods

		public override void LoadContent()
		{
			base.LoadContent();

			// Create our menu entries.
			var optionsMenuEntry = new MenuEntry(ScreenManager.Styles.MenuEntryStyle, "Options");
			var touchMenuEntry = new MenuEntry(ScreenManager.Styles.MenuEntryStyle, "Touch Test");
			var exitMenuEntry = new MenuEntry(ScreenManager.Styles.MenuEntryStyle, "Exit");

			// Hook up menu event handlers.
			optionsMenuEntry.Selected += OptionsMenuEntrySelected;
			touchMenuEntry.Selected += TouchMenuEntrySelected;
			exitMenuEntry.Selected += OnExit;

			// Add entries to the menu.
			AddMenuEntry(optionsMenuEntry);
			AddMenuEntry(touchMenuEntry);
			AddMenuEntry(exitMenuEntry); //TODO: only remove this entry for the demo
		}

		#endregion //Methods

		#region Handle Input

		/// <summary>
		/// Event handler for when the High Scores menu entry is selected.
		/// </summary>
		private void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
		{
			//screen to adjust mic sensitivity
			ScreenManager.AddScreen(new OptionsScreen(), null);
		}

		/// <summary>
		/// Event handler for when the High Scores menu entry is selected.
		/// </summary>
		private void TouchMenuEntrySelected(object sender, PlayerIndexEventArgs e)
		{
			//screen to adjust mic sensitivity
			ScreenManager.AddScreen(new TouchOptionsScreen(), null);
		}

		/// <summary>
		/// When the user cancels the main menu, ask if they want to exit the sample.
		/// </summary>
		protected void OnExit(object sender, PlayerIndexEventArgs e)
		{
			const string message = "Are you sure you want to exit?";
			var confirmExitMessageBox = new MessageBoxScreen(message, false);
			confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;
			ScreenManager.AddScreen(confirmExitMessageBox, e.PlayerIndex);
		}

		/// <summary>
		/// Event handler for when the user selects ok on the "are you sure
		/// you want to exit" message box.
		/// </summary>
		private void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
		{
			ScreenManager.Game.Exit();
		}

		private void MarketplaceDenied(object sender, PlayerIndexEventArgs e)
		{
			ScreenManager.Game.Exit();
		}

		/// <summary>
		/// Ignore the cancel message from the main menu
		/// </summary>
		public override void OnCancel(PlayerIndex? playerIndex)
		{
			//do nothing here!
		}

		#endregion
	}
}