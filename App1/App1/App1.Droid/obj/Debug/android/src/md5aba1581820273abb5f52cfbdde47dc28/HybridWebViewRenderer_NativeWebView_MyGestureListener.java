package md5aba1581820273abb5f52cfbdde47dc28;


public class HybridWebViewRenderer_NativeWebView_MyGestureListener
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFling:(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z:GetOnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler\n" +
			"";
		mono.android.Runtime.register ("XLabs.Forms.Controls.HybridWebViewRenderer+NativeWebView+MyGestureListener, XLabs.Forms.Droid, Version=2.0.5782.12263, Culture=neutral, PublicKeyToken=null", HybridWebViewRenderer_NativeWebView_MyGestureListener.class, __md_methods);
	}


	public HybridWebViewRenderer_NativeWebView_MyGestureListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HybridWebViewRenderer_NativeWebView_MyGestureListener.class)
			mono.android.TypeManager.Activate ("XLabs.Forms.Controls.HybridWebViewRenderer+NativeWebView+MyGestureListener, XLabs.Forms.Droid, Version=2.0.5782.12263, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public HybridWebViewRenderer_NativeWebView_MyGestureListener (md5aba1581820273abb5f52cfbdde47dc28.HybridWebViewRenderer p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == HybridWebViewRenderer_NativeWebView_MyGestureListener.class)
			mono.android.TypeManager.Activate ("XLabs.Forms.Controls.HybridWebViewRenderer+NativeWebView+MyGestureListener, XLabs.Forms.Droid, Version=2.0.5782.12263, Culture=neutral, PublicKeyToken=null", "XLabs.Forms.Controls.HybridWebViewRenderer, XLabs.Forms.Droid, Version=2.0.5782.12263, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public boolean onFling (android.view.MotionEvent p0, android.view.MotionEvent p1, float p2, float p3)
	{
		return n_onFling (p0, p1, p2, p3);
	}

	private native boolean n_onFling (android.view.MotionEvent p0, android.view.MotionEvent p1, float p2, float p3);

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
