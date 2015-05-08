package cirrious.mvvmcross.droid.fragging;


public class MvxCachingFragmentActivity
	extends cirrious.mvvmcross.droid.fragging.MvxFragmentActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onPostCreate:(Landroid/os/Bundle;)V:GetOnPostCreate_Landroid_os_Bundle_Handler\n" +
			"n_onSaveInstanceState:(Landroid/os/Bundle;)V:GetOnSaveInstanceState_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Cirrious.MvvmCross.Droid.Fragging.MvxCachingFragmentActivity, Cirrious.MvvmCross.Droid.Fragging, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxCachingFragmentActivity.class, __md_methods);
	}


	public MvxCachingFragmentActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxCachingFragmentActivity.class)
			mono.android.TypeManager.Activate ("Cirrious.MvvmCross.Droid.Fragging.MvxCachingFragmentActivity, Cirrious.MvvmCross.Droid.Fragging, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onPostCreate (android.os.Bundle p0)
	{
		n_onPostCreate (p0);
	}

	private native void n_onPostCreate (android.os.Bundle p0);


	public void onSaveInstanceState (android.os.Bundle p0)
	{
		n_onSaveInstanceState (p0);
	}

	private native void n_onSaveInstanceState (android.os.Bundle p0);

	java.util.ArrayList refList;
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
