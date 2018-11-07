package assignment.pkg4;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

public class Login extends javax.swing.JFrame {

    public Login() {
        initComponents();
    }
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        usernameJLabel = new javax.swing.JLabel();
        passwordJLabel = new javax.swing.JLabel();
        usernameJTextField = new javax.swing.JTextField();
        loginJBtn = new javax.swing.JButton();
        exitJBtn = new javax.swing.JButton();
        loginTitleJLabel = new javax.swing.JLabel();
        jPasswordField1 = new javax.swing.JPasswordField();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setBackground(new java.awt.Color(255, 255, 255));

        usernameJLabel.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        usernameJLabel.setText("UserName");

        passwordJLabel.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        passwordJLabel.setText("Password");

        usernameJTextField.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N

        loginJBtn.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        loginJBtn.setText("Login");
        loginJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                loginJBtnActionPerformed(evt);
            }
        });

        exitJBtn.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        exitJBtn.setText("Exit");
        exitJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                exitJBtnActionPerformed(evt);
            }
        });

        loginTitleJLabel.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        loginTitleJLabel.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Images/logo.gif"))); // NOI18N
        loginTitleJLabel.setText("LIT Realty - System Login");

        jPasswordField1.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(33, 33, 33)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(loginTitleJLabel, javax.swing.GroupLayout.DEFAULT_SIZE, 285, Short.MAX_VALUE)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(passwordJLabel)
                            .addComponent(usernameJLabel))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(exitJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 82, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(29, 29, 29)
                                .addComponent(loginJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 82, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                .addComponent(usernameJTextField, javax.swing.GroupLayout.DEFAULT_SIZE, 200, Short.MAX_VALUE)
                                .addComponent(jPasswordField1)))
                        .addGap(0, 0, Short.MAX_VALUE)))
                .addGap(40, 40, 40))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(loginTitleJLabel)
                .addGap(32, 32, 32)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(usernameJLabel)
                    .addComponent(usernameJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(20, 20, 20)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(passwordJLabel)
                    .addComponent(jPasswordField1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(exitJBtn, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(loginJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 34, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(26, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void exitJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_exitJBtnActionPerformed
        System.exit(0);
    }//GEN-LAST:event_exitJBtnActionPerformed

    private void loginJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_loginJBtnActionPerformed
        login();
    }//GEN-LAST:event_loginJBtnActionPerformed
    
    private void login()
    {   
        try 
        {
            Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/litrealty", "root", "");
            
            //String sql = "{call litrealty.login(" + usernameJTextField.getText() + "," + passwordJTextField.getText() + ")}";
            String sql = "{ call login(?,?) }";
            CallableStatement stmt = conn.prepareCall(sql);
            stmt.setString(1, usernameJTextField.getText());
            stmt.setString(2, jPasswordField1.getText());
            
            ResultSet rs = stmt.executeQuery();
            
            if(rs.next() == true)
            {
                MainJFrame main = new MainJFrame();
                
                this.dispose();
                main.show();
            }
            
            else
            {
                displayMessage("Login Failed");
            }
        } 
        catch (SQLException ex) 
        {
            displayMessage(ex.toString());
        }
        
        
    }
    
    private void displayMessage(String message)
    {
        JFrame frame = new JFrame();
        JOptionPane.showMessageDialog(frame, message, "Error", JOptionPane.INFORMATION_MESSAGE);
    }
    
    public static void main(String args[]) {
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
            java.util.logging.Logger.getLogger(Login.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Login.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Login.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Login.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new Login().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton exitJBtn;
    private javax.swing.JPasswordField jPasswordField1;
    private javax.swing.JButton loginJBtn;
    private javax.swing.JLabel loginTitleJLabel;
    private javax.swing.JLabel passwordJLabel;
    private javax.swing.JLabel usernameJLabel;
    private javax.swing.JTextField usernameJTextField;
    // End of variables declaration//GEN-END:variables
}
