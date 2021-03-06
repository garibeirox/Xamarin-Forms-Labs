// ***********************************************************************
// Assembly         : XLabs.Forms.iOS
// Author           : XLabs Team
// Created          : 12-27-2015
// 
// Last Modified By : XLabs Team
// Last Modified On : 01-04-2016
// ***********************************************************************
// <copyright file="ExtendedEditorRenderer.cs" company="XLabs Team">
//     Copyright (c) XLabs Team. All rights reserved.
// </copyright>
// <summary>
//       This project is licensed under the Apache 2.0 license
//       https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/LICENSE
//       
//       XLabs is a open source project that aims to provide a powerfull and cross 
//       platform set of controls tailored to work with Xamarin Forms.
// </summary>
// ***********************************************************************
// 

using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XLabs.Forms.Controls;

[assembly: ExportRenderer(typeof(ExtendedEditor), typeof(ExtendedEditorRenderer))]

namespace XLabs.Forms.Controls
{
	/// <summary>
	/// Class ExtendedEditorRenderer.
	/// </summary>
	public class ExtendedEditorRenderer : EditorRenderer
	{
		/// <summary>
		/// The _left swipe gesture recognizer
		/// </summary>
		private UISwipeGestureRecognizer _leftSwipeGestureRecognizer;
		/// <summary>
		/// The _right swipe gesture recognizer
		/// </summary>
		private UISwipeGestureRecognizer _rightSwipeGestureRecognizer;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExtendedEditorRenderer"/> class.
		/// </summary>
		public ExtendedEditorRenderer ()
		{
		}

		/// <summary>
		/// Called when [element changed].
		/// </summary>
		/// <param name="e">The e.</param>
		protected override void OnElementChanged (ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged (e);

			var view = (ExtendedEditor)Element;
			if (view != null)
			{
				Control.Font = view.Font.ToUIFont();
			}

			if (e.OldElement == null)
			{
				_leftSwipeGestureRecognizer = new UISwipeGestureRecognizer(() => view.OnLeftSwipe(this, EventArgs.Empty))
					{
						Direction = UISwipeGestureRecognizerDirection.Left
					};

				_rightSwipeGestureRecognizer = new UISwipeGestureRecognizer(()=> view.OnRightSwipe(this, EventArgs.Empty))
					{
						Direction = UISwipeGestureRecognizerDirection.Right
					};

				Control.AddGestureRecognizer(_leftSwipeGestureRecognizer);
				Control.AddGestureRecognizer(_rightSwipeGestureRecognizer);
			}

			if (e.NewElement == null)
			{
				Control.RemoveGestureRecognizer(_leftSwipeGestureRecognizer);
				Control.RemoveGestureRecognizer(_rightSwipeGestureRecognizer);
			}
		}
	}
}

