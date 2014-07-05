/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2014 Faiz Malkani
 * Copyright (c) 2014 Tomasz Cielecki
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using Android.Animation;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;

namespace DK.Ostebaronen.FloatingActionButton
{
    public class Fab : View
    {
        private Paint _buttonPaint, _drawablePaint;
        private Bitmap _bitmap;
        private int _screenHeight;
        private float _currentY;
        private bool _hidden;

        public Fab(Context context, IAttributeSet attributeSet)
            : base(context, attributeSet)
        {
            Init(Color.White);
        }

        public Fab(Context context)
            : base(context)
        {
            Init(Color.White);
        }

        public Fab(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        { }

        public Color FabColor
        {
            set { Init(value); }
        }

        public Drawable FabDrawable
        {
            set
            {
                var drawable = value;
                _bitmap = ((BitmapDrawable) drawable).Bitmap;
                Invalidate();
            }
        }

        private void Init(Color fabColor)
        {
            SetWillNotDraw(false);
            SetLayerType(LayerType.Software, null);
            _buttonPaint = new Paint(PaintFlags.AntiAlias) {Color = fabColor};
            _buttonPaint.SetStyle(Paint.Style.Fill);
            _buttonPaint.SetShadowLayer(10.0f, 0.0f, 3.5f, Color.Argb(100, 0, 0, 0));
            _drawablePaint = new Paint(PaintFlags.AntiAlias);
            Invalidate();

            var windowManager = Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            var display = windowManager.DefaultDisplay;
            var size = new Point();
            display.GetSize(size);
            _screenHeight = size.Y;
        }

        protected override void OnDraw(Canvas canvas)
        {
            Clickable = true;
            canvas.DrawCircle(Width/2f, Height/2f, Width/2.6f, _buttonPaint);
            canvas.DrawBitmap(_bitmap, (Width - _bitmap.Width) / 2f, (Height - _bitmap.Height) / 2f, _drawablePaint);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Up)
                Alpha = 1.0f;
            else if (e.Action == MotionEventActions.Down)
                Alpha = 0.6f;

            return base.OnTouchEvent(e);
        }

        public int DpToPx(int dp)
        {
            var displayMetrics = Context.Resources.DisplayMetrics;
            var px = Math.Round(dp * (displayMetrics.Xdpi / (int) DisplayMetricsDensity.Default));
            return (int)px;
        }

        public void Hide()
        {
            if (_hidden) return;

            _currentY = GetY();
            var hideAnimation = ObjectAnimator.OfFloat(this, "Y", _screenHeight);
            hideAnimation.SetInterpolator(new AccelerateInterpolator());
            hideAnimation.Start();
            _hidden = true;
        }

        public void Show()
        {
            if (!_hidden) return;

            var hideAnimation = ObjectAnimator.OfFloat(this, "Y", _currentY);
            hideAnimation.SetInterpolator(new DecelerateInterpolator());
            hideAnimation.Start();
            _hidden = false;
        }
    }
}
