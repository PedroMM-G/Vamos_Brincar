import androidx.appcompat.widget.Toolbar;

import java.io.IOException;
import java.util.concurrent.Executor;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;

class HTTPRequest{

    static void getResquest(final Activity a, String urlKeyMerged)
    {
        OkHttpClient client = new OkHttpClient();
        Request request = new Request.Builder()
                .url(urlKeyMerged)
                .build();
        client.newCall(request).enqueue(new Callback() {
            @Override
            public void onFailure(Call call, IOException e) {
                e.printStackTrace();
                a.finish();
            }
            @Override
            public void onResponse(Call call, Response response) throws IOException {
                if (response.isSuccessful()) {
                    final String myResponse = response.body().string();
                    a.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            //mTextViewResult.setText(myResponse);
                            Log.i("----> VAI!","MENSAGEM ENTREGUE!");
                            a.finish();
                        }
                    });
                }
                else
                    a.finish();
            }
        });

    }
}

public class MainActivity extends AppCompatActivity {

    private Executor executor;
    private BiometricPrompt biometricPrompt;
    private BiometricPrompt.PromptInfo promptInfo;

    String uuid = "";
    String responseuri  = "";
    String imei = "";

    private void sendResponseBack(String result)
    {
        if (uuid!="" && responseuri != "" && result != "") {
            String url = responseuri + "?uuid="+uuid+"&key="+result;
            HTTPRequest.getResquest(MainActivity.this, url);
            return;
        }
        Toast.makeText(this, "Algo correu mal (campos vazios)", Toast.LENGTH_LONG).show();
        MainActivity.this.finish();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Uri uri = this.getIntent().getData();
        UrlQuerySanitizer sanitizer = new UrlQuerySanitizer();
        sanitizer.setAllowUnregisteredParamaters(true);
        sanitizer.parseUrl(uri.toString());
        uuid = sanitizer.getValue("uuid");
        responseuri = sanitizer.getValue("responseuri");
        Toast.makeText(this, responseuri, Toast.LENGTH_SHORT).show();

        executor = androidx.core.content.ContextCompat.getMainExecutor(this);
        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.P) {
            biometricPrompt = new BiometricPrompt(MainActivity.this,
                    executor, new BiometricPrompt.AuthenticationCallback(){
                @Override
                public void onAuthenticationError(int errorCode,
                                                  @NonNull CharSequence errString) {
                    super.onAuthenticationError(errorCode, errString);
                    Toast.makeText(getApplicationContext(),
                            "Erro de autenticação: " + errString, Toast.LENGTH_SHORT)
                            .show();
                    sendResponseBack("0");
                }

                @Override
                public void onAuthenticationSucceeded(
                        @NonNull BiometricPrompt.AuthenticationResult result) {
                    super.onAuthenticationSucceeded(result);
                    try {
                        imei = Settings.Secure.getString(MainActivity.this.getContentResolver(),
                                Settings.Secure.ANDROID_ID);
                        Toast.makeText(getApplicationContext(), imei, Toast.LENGTH_SHORT).show();
                        sendResponseBack(imei);
                    }
                    catch (Exception ex)
                    {
                        sendResponseBack("0");
                    }
                }

                @Override
                public void onAuthenticationFailed() {
                    super.onAuthenticationFailed();
                    Toast.makeText(getApplicationContext(), "A autenticação falhou...",
                            Toast.LENGTH_SHORT)
                            .show();
                    sendResponseBack("0");
                }
            });
        }

        promptInfo = new BiometricPrompt.PromptInfo.Builder()
                .setTitle("Biometric login - Prochild")
                .setSubtitle("Login com recurso às credenciais biométricas")
                .setNegativeButtonText("Use a password de utilizador")
                .build();

        // Prompt appears when user clicks "Log in".
        // Consider integrating with the keystore to unlock cryptographic operations,
        // if needed by your app.
        biometricPrompt.authenticate(promptInfo);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onPointerCaptureChanged(boolean hasCapture) {
    }

    @Override
    public void onBackPressed() {
        sendResponseBack("0");
        super.onBackPressed();
    }
}
