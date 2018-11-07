package assignment.pkg6;

import java.awt.Color;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Timer;
import java.util.TimerTask;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;

public class Client extends javax.swing.JFrame 
{
    private final int port = 5000;
    private volatile Socket connection = null;
    private volatile DataOutputStream toServer = null;
    private volatile DataInputStream fromServer = null;
    private volatile Boolean connected = false;
    
    public Client() 
    {
        initComponents();
        connect();
    }
    
    private void connect() 
    {
        //Thread to deal with connection to the server
        Thread connectThread = new Thread()
        {              
            public void run()
            {   
                while(true)
                {
                    if(connected == false)
                    {                    
                        try
                        {
                            connection = new Socket("localhost", port); //Sets up connection using ip and port   
                            connected(); //Displays "Connected" in client and sets connected boolean to true                           
                        } 
                        catch (IOException ex) 
                        { 
                            disconnected(); //Displays "Disconnected" in the client and sets connected boolean to false                           
                        } 
                        
                        try 
                        {
                            Thread.sleep(5000); //Pauses Thread for 3 seconds to reduce server traffic
                        } 
                        catch (InterruptedException ex) 
                        {
                            Logger.getLogger(Client.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    }
                    
                    /*
                    else
                    {
                        try
                        {     
                           
                            if(!sendMessage("/ping")) //Sets to disconnected if server doesn't reply
                            {   
                                disconnected();                          
                            }   
                            Thread.sleep(5000); //Pauses Thread for 3 seconds to reduce server traffic
                        }            
                        catch (InterruptedException ex) 
                        {
                            Logger.getLogger(Client.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    }
                    */
                } 
            }
        };
                
        connectThread.start();
    }
    
    private Boolean sendMessage(String message)
    {
        try 
        {            
            toServer = new DataOutputStream(connection.getOutputStream()); //Sets up output stream to server 
            byte[] data = message.getBytes("UTF-8");
            toServer.writeInt(data.length);     
            toServer.write(data);  
            toServer.flush();
            
            
            //This part is slightly fucked
            /*
            fromServer = new DataInputStream(connection.getInputStream());
            int length = fromServer.readInt();
            byte[] receiveData = new byte[length];
            fromServer.readFully(receiveData);
            String receiveMessage = new String(receiveData,"UTF-8");
            
            if(receiveMessage.equalsIgnoreCase("/pong")) //Checks if server replies to ping
            {               
                //chatTextArea.append("\nServer: " + receiveMessage);
                return true;
            }
            */
        } 
        catch (IOException ex) 
        {
            System.out.print("Error Sending Message");
        }    
        
        return false;
    }
    
    private void connected()
    {
        isConnectedLabel.setText("Connected");
        isConnectedLabel.setForeground(Color.GREEN);
        connected = true;
    }
    
    private void disconnected()
    {
        isConnectedLabel.setText("Disconnected");
        isConnectedLabel.setForeground(Color.RED);
        connected = false;
    }
    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jScrollPane1 = new javax.swing.JScrollPane();
        chatTextArea = new javax.swing.JTextArea();
        messageTextArea = new javax.swing.JTextField();
        sendMessageBtn = new javax.swing.JButton();
        isConnectedLabel = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        chatTextArea.setColumns(20);
        chatTextArea.setRows(5);
        jScrollPane1.setViewportView(chatTextArea);

        sendMessageBtn.setText("Send");
        sendMessageBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                sendMessageBtnActionPerformed(evt);
            }
        });

        isConnectedLabel.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        isConnectedLabel.setForeground(new java.awt.Color(255, 0, 51));
        isConnectedLabel.setHorizontalAlignment(javax.swing.SwingConstants.TRAILING);
        isConnectedLabel.setText("Disconnected");
        isConnectedLabel.setToolTipText("Not connected to messaging server");
        isConnectedLabel.setHorizontalTextPosition(javax.swing.SwingConstants.LEFT);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane1)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(messageTextArea, javax.swing.GroupLayout.PREFERRED_SIZE, 296, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(sendMessageBtn, javax.swing.GroupLayout.DEFAULT_SIZE, 68, Short.MAX_VALUE))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addGap(0, 0, Short.MAX_VALUE)
                        .addComponent(isConnectedLabel)
                        .addGap(21, 21, 21)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 252, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(messageTextArea, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(sendMessageBtn))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(isConnectedLabel, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void sendMessageBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_sendMessageBtnActionPerformed
        sendMessage(messageTextArea.getText());
    }//GEN-LAST:event_sendMessageBtnActionPerformed

    public static void main(String args[]) 
    {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(Client.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Client.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Client.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Client.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() 
        {
            public void run() 
            {
                new Client().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JTextArea chatTextArea;
    private javax.swing.JLabel isConnectedLabel;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextField messageTextArea;
    private javax.swing.JButton sendMessageBtn;
    // End of variables declaration//GEN-END:variables
}
