package md5afd6673e0ee9440e9d745cae3b1062af;


public class CalendarMonthPageTransformer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.ViewPager.PageTransformer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_transformPage:(Landroid/view/View;F)V:GetTransformPage_Landroid_view_View_FHandler:Android.Support.V4.View.ViewPager/IPageTransformerInvoker, Xamarin.Android.Support.v4\n" +
			"";
		mono.android.Runtime.register ("XLabs.Forms.Controls.MonoDroid.TimesSquare.CalendarMonthPageTransformer, XLabs.Forms.Droid, Version=2.0.5782.12263, Culture=neutral, PublicKeyToken=null", CalendarMonthPageTransformer.class, __md_methods);
	}


	public CalendarMonthPageTransformer () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CalendarMonthPageTransformer.class)
			mono.android.TypeManager.Activate ("XLabs.Forms.Controls.MonoDroid.TimesSquare.CalendarMonthPageTransformer, XLabs.Forms.Droid, Version=2.0.5782.12263, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void transformPage (android.view.View p0, float p1)
	{
		n_transformPage (p0, p1);
	}

	private native void n_transformPage (android.view.View p0, float p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
