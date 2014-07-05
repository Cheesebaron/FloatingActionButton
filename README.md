FloatingActionButton
====================

A port of [Faiz Malkani's][faiz] [FloatingActionButton][fab] backport, which backports the Floating Action Button from Android L to API 15 and up.

Drawables contained in the FAB are 24dp, and this is the preferred size.

![ss2][ss2]

Instructions
============

1. Use a `FrameLayout` to layer your layouts, and place the FAB in the bottom to make it appear on top:

    ```xml
    <FrameLayout
        xmlns:android="http://schemas.android.com/apk/res/android"
        xmlns:tools="http://schemas.android.com/tools"
        android:layout_width="match_parent"
        android:layout_height="match_parent">

        <!--
        Your layouts here. Do not put anything below the FAB layout,
        unless you want it to overlap it.
        -->


        <dk.ostebaronen.floatingactionbutton.Fab
            android:id="@+id/fabbutton"
            android:layout_width="72dp"
            android:layout_height="72dp"
            android:layout_gravity="bottom|right"
            android:layout_marginBottom="16dp"
            android:layout_marginRight="16dp" />

    </FrameLayout>
    ```

2. Initialize FAB in your Activity's `OnCreate()` method:

    ```csharp
    var fab = FindViewById<Fab>(Resource.Id.fabbutton);
    ```

3. Use the `FabColor` and `FabDrawable` methods to change the color and image inside of it:

    ```csharp
    fab.FabColor = Color.Blue;
    fab.FabDrawable = Resources.GetDrawable(Resource.Drawable.ic_my_fab);
    ```

4. Use `Hide()` and `Show()` to hide and show the FAB. Use the `Alpha` property to set the transparency. Assign the `Click` event to handle user clicks on the FAB.

License
=======
This derivative work is licensed under [The MIT License (MIT)][license].


[faiz]: https://github.com/FaizMalkani
[fab]: https://github.com/FaizMalkani/FloatingActionButton
[license]: https://github.com/Cheesebaron/FloatingActionButton/blob/master/LICENSE
[ss1]: /Screenshots/1_small.png
[ss2]: /Screenshots/2_small.png
