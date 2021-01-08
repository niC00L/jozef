package com.nicool.foxrun;
 
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.os.IBinder;
import android.util.Log;
import android.widget.Toast;

 
import com.unity3d.player.UnityPlayerActivity;
 
public class TestActivity extends UnityPlayerActivity {
 
    private ConsumerService mBoundService;
    private boolean mServiceBound = false;

    private List<Message> mMessages = Collections.synchronizedList(new ArrayList<Message>());

 
    public static Context sContext;
 
    private ServiceConnection mServiceConnection = new ServiceConnection() {
        @Override
        public void onServiceConnected(ComponentName componentName, IBinder service) {
            ConsumerService.LocalBinder myBinder = (ConsumerService.LocalBinder) service;
            mBoundService = myBinder.getService();
            mServiceBound = true;
            Log.d("Unity", "Service connected: " + mBoundService);
        }
 
        @Override
        public void onServiceDisconnected(ComponentName componentName) {
            mServiceBound = false;
        }
    };
 
    @Override
    protected void onCreate(Bundle bundle) {
        super.onCreate(bundle);
        sContext = this;
    }
 
    public void startTracking() {
        Intent intent = new Intent(this, ConsumerService.class);
        bindService(intent, mServiceConnection, Context.BIND_AUTO_CREATE);
    }

    public void connect() {
        mBoundService.findPeers();
    }

    public void addMessage(final Message msg){
        if (mMessages.size() == 5) {
            mMessages.remove(0);
        }
        mMessages.add(msg);
    }
 
    public void stopTracking() {
        if (mServiceBound) {
            unbindService(mServiceConnection);
            mServiceBound = false;
        }
    }

     private static final class Message {
        String data;

        public Message(String data) {
            super();
            this.data = data;
        }
    }
}