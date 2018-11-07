package assignment.pkg6;

import java.awt.EventQueue;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.SwingUtilities;

public class Server extends JFrame 
{
    private final int port = 5000;
    private volatile ServerSocket socket;
            
    public Server() 
    {
        initComponents();
        this.setLocationRelativeTo(null);
         
        //temp code for opening client at runtime
        Client client = new Client();
        client.show();
    }
    
    private void startServer()
    {     
        try 
        {           
            socket = new ServerSocket(port); //create server socket
           
            serverConsole.append("Listening on port " + port);
            serverConsole.append("\nAwaiting Connections...");
            
            startServerBtn.setEnabled(false);
            stopServerBtn.setEnabled(true);          
        }
        catch(IOException ex) 
        {
            serverConsole.append("\nError: Could not listen on port " + port);
        }
               
        awaitConnection(socket);  
    }
    
    private void awaitConnection(ServerSocket server)
    {
        Thread connectionThread = new Thread()
        {         
            public void run()
            {           
                try 
                {       
                    while(true)
                    {
                       Socket connection = server.accept();                                
                       handleClient(connection);
                    }       
                } 
                catch (IOException ex) 
                {
                    serverConsole.append("Error connecting to client: " + ex.getMessage());
                }         
            }      
        };   
              
        connectionThread.start();      
    }
    
    private void handleClient(Socket connection)
    {      
        Thread clientThread = new Thread()
        {
            public void run()
            {   
                try
                {                  
                    // set up input stream
                    while(true)
                    {
                        DataInputStream fromClient = new DataInputStream(connection.getInputStream());
                    
                        int length = fromClient.readInt();
                        byte[] data = new byte[length];
                        fromClient.readFully(data);
                        String message = new String(data,"UTF-8");
                        serverConsole.append("\nClient: " + message); 
                        
                        if(message.equalsIgnoreCase("/ping"))
                        {                           
                            DataOutputStream toClient = new DataOutputStream(connection.getOutputStream());
                            String sendMessage = "/pong";
                            byte[] sendData = sendMessage.getBytes("UTF-8");
                            toClient.writeInt(sendData.length);    
                            toClient.write(sendData);    
                            toClient.flush(); 
                        } 
                    } 
                }   
                catch (IOException ex) 
                {
                    Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
        };
        
        clientThread.start();     
    }
    
    private void stopServer()
    {
        socket = null;
        startServerBtn.setEnabled(true);
        stopServerBtn.setEnabled(false); 
        serverConsole.append("\nServer Shut Down");
    }
        
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        serverLabel = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        serverConsole = new javax.swing.JTextArea();
        startServerBtn = new javax.swing.JButton();
        stopServerBtn = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        serverLabel.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        serverLabel.setText("Messaging Server Console");

        serverConsole.setEditable(false);
        serverConsole.setBackground(new java.awt.Color(0, 0, 0));
        serverConsole.setColumns(20);
        serverConsole.setForeground(new java.awt.Color(255, 255, 255));
        serverConsole.setRows(5);
        jScrollPane1.setViewportView(serverConsole);

        startServerBtn.setText("Start Server ");
        startServerBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                startServerBtnActionPerformed(evt);
            }
        });

        stopServerBtn.setText("Stop Server");
        stopServerBtn.setEnabled(false);
        stopServerBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                stopServerBtnActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(jScrollPane1))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(103, 103, 103)
                        .addComponent(serverLabel)
                        .addGap(0, 106, Short.MAX_VALUE))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addGap(0, 0, Short.MAX_VALUE)
                        .addComponent(stopServerBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 95, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(startServerBtn)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(serverLabel)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 273, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(startServerBtn)
                    .addComponent(stopServerBtn))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void startServerBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_startServerBtnActionPerformed
        startServer();
    }//GEN-LAST:event_startServerBtnActionPerformed

    private void stopServerBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_stopServerBtnActionPerformed
        stopServer();
    }//GEN-LAST:event_stopServerBtnActionPerformed

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
            java.util.logging.Logger.getLogger(Server.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Server.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Server.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Server.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        SwingUtilities.invokeLater(new Runnable() 
        {
            @Override
            public void run() 
            {
                new Server().setVisible(true);
            }
        });     
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextArea serverConsole;
    private javax.swing.JLabel serverLabel;
    private javax.swing.JButton startServerBtn;
    private javax.swing.JButton stopServerBtn;
    // End of variables declaration//GEN-END:variables
}
