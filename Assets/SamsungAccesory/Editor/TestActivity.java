package com.nicool.foxrun;
 
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.os.IBinder;
import android.util.Log;
import android.widget.Toast;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

 
import com.unity3d.player.UnityPlayerActivity;
 
public class TestActivity extends UnityPlayerActivity {
 
    private ConsumerService mBoundService;
    private boolean mServiceBound = false;

    private static List<String> mMessages = Collections.synchronizedList(new ArrayList<String>());

 
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
    public void getData() {
        mBoundService.sendData("give me data");
    }

    public static int getNewestHeartRate() {
    int hr = -1;
    if (mMessages.size() > 0) {
        hr = Integer.parseInt(mMessages.get(mMessages.size() - 1));
    }
        return hr;
    }

    public static void addMessage(String msg){
        if (mMessages.size() == 5) {
            mMessages.remove(0);
        }
        mMessages.add(msg);
        Log.d("Unity", "message added " + msg);
    }
 
    public void stopTracking() {
        if (mServiceBound) {
            mBoundService.closeConnection();
            unbindService(mServiceConnection);
            mServiceBound = false;
        }
    }
}