﻿using InputHelper;
using MenuBuddy;
using Microsoft.Xna.Framework;
using ResolutionBuddy;

namespace MenuBuddySample
{
	public class BigScrollTest : WidgetScreen
	{
		public BigScrollTest() : base("Big Scroll Test")
		{
			CoverOtherScreens = true;
			CoveredByOtherScreens = true;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			AddCancelButton();

			var stack = GetStack();

			//create the scroll layout and add the stack
			var scroll = new ScrollLayout()
			{
				Horizontal = HorizontalAlignment.Center,
				Vertical = VerticalAlignment.Center,
				Size = new Vector2(350, 512),
				Position = Resolution.ScreenArea.Center
			};

			scroll.AddItem(stack);
			AddItem(scroll);

			var stack1 = GetStack();
			stack1.Position = new Point(Resolution.ScreenArea.Center.X / 2, Resolution.ScreenArea.Top);
			AddItem(stack1);
		}

		private StackLayout GetStack()
		{
			//create the stack layout and add some labels
			var stack = new StackLayout()
			{
				Alignment = StackAlignment.Top,
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Center
			};

			for (int i = 100; i < 120; i++)
			{
				var text = i.ToString();
				var label = new Label(text, FontSize.Small)
				{
					Horizontal = HorizontalAlignment.Center,
					Vertical = VerticalAlignment.Center,
				};

				var button = new RelativeLayoutButton()
				{
					Horizontal = HorizontalAlignment.Center,
					Vertical = VerticalAlignment.Center,
					HasOutline = true,
					HasBackground = false,
					Layer = i				
				};
				button.Size = new Vector2(label.Rect.Width, label.Rect.Height);
				button.AddItem(label);
				button.OnClick += ((object obj, ClickEventArgs e) =>
				{
					ScreenManager.AddScreen(new OkScreen(text));
				});

				stack.AddItem(button);
			}

			return stack;
		}
	}
}
