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
			var startGame = new MenuEntry("Start Game");
			startGame.Selected += ((object sender, PlayerIndexEventArgs e) =>
			{
				LoadingScreen.Load(ScreenManager, true, null, new TopScreen());
			});
			AddMenuEntry(startGame);

			var optionsMenuEntry = new MenuEntry("Options");
			optionsMenuEntry.Selected += OptionsMenuEntrySelected;
			AddMenuEntry(optionsMenuEntry);

			var touchMenuEntry = new MenuEntry("Touch Test");
			touchMenuEntry.Selected += TouchMenuEntrySelected;
			AddMenuEntry(touchMenuEntry);

			var entry = new MenuEntry("Scroll Test");
			entry.Selected += ((object obj, PlayerIndexEventArgs e) =>
			{
				ScreenManager.AddScreen(new ScrollOptionsScreen());
			});
			AddMenuEntry(entry);

			var exitMenuEntry = new MenuEntry("Exit");
			exitMenuEntry.Selected += OnExit;
			AddMenuEntry(exitMenuEntry);
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
		public override void OnCancel(object sender, PlayerIndexEventArgs e)
		{
			//do nothing here!
		}

		#endregion
	}
}