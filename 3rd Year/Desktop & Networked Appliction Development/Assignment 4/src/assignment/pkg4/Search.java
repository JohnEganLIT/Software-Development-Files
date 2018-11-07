package assignment.pkg4;

import java.awt.event.KeyEvent;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

public class Search extends javax.swing.JFrame {
    public Search() {
        initComponents();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        locationJLabel = new javax.swing.JLabel();
        priceRangeJLabel = new javax.swing.JLabel();
        locationJTextField = new javax.swing.JTextField();
        priceRangeJComboBox = new javax.swing.JComboBox<>();
        jLabel3 = new javax.swing.JLabel();
        exitJBtn = new javax.swing.JButton();
        searchJBtn = new javax.swing.JButton();
        loginTitleJLabel1 = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        locationJLabel.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        locationJLabel.setText("Enter Location");

        priceRangeJLabel.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        priceRangeJLabel.setText("Enter Price Range");

        locationJTextField.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N

        priceRangeJComboBox.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        priceRangeJComboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Any", "€100,000 - €150,000", "€150,000 - €200,000", "€200,000 - €250,000", "€250,000 - €350,000", "€350,000 - €500,000", "Over €500,000" }));

        jLabel3.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        jLabel3.setText("Please Enter Your Search Criteria");

        exitJBtn.setText("Exit");
        exitJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                exitJBtnActionPerformed(evt);
            }
        });

        searchJBtn.setText("Search!");
        searchJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                searchJBtnActionPerformed(evt);
            }
        });

        loginTitleJLabel1.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        loginTitleJLabel1.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Images/logo.gif"))); // NOI18N
        loginTitleJLabel1.setText("  LIT Realty");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(priceRangeJLabel)
                            .addComponent(locationJLabel))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(exitJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 100, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(searchJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 100, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addComponent(locationJTextField)
                            .addComponent(priceRangeJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, 206, javax.swing.GroupLayout.PREFERRED_SIZE)))
                    .addComponent(jLabel3)
                    .addComponent(loginTitleJLabel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addGap(35, 35, 35))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(loginTitleJLabel1)
                .addGap(18, 18, 18)
                .addComponent(jLabel3)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(locationJLabel)
                    .addComponent(locationJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(priceRangeJLabel)
                    .addComponent(priceRangeJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(26, 26, 26)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(exitJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 40, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(searchJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 40, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(22, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void exitJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_exitJBtnActionPerformed
        MainJFrame main = new MainJFrame();
        this.dispose();
        main.show();
    }//GEN-LAST:event_exitJBtnActionPerformed

    private void searchJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_searchJBtnActionPerformed
        Search();
    }//GEN-LAST:event_searchJBtnActionPerformed
    
    private void Search()
    {
        int highPrice = 0, lowPrice = 0;
                
        switch(priceRangeJComboBox.getSelectedIndex())
        {
            case 0:
                lowPrice = 0;
                highPrice = 999999999;
                break;
            case 1:
                lowPrice = 100000;
                highPrice = 150000;
                break;
            case 2:
                lowPrice = 150000;
                highPrice = 200000;
                break;
            case 3:
                lowPrice = 200000;
                highPrice = 250000;
                break;
            case 4: 
                lowPrice = 250000;
                highPrice = 350000;
                break;
            case 5:
                lowPrice = 350000;
                highPrice = 500000;
                break;
            case 6:
                lowPrice = 500000;
                highPrice = 999999999;
        }
        
        try 
        {
            Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/litrealty", "root", "");

            String sql = "{ call SearchProperties(?,?,?) }";
            CallableStatement stmt = conn.prepareCall(sql);
            stmt.setString(1, locationJTextField.getText());
            stmt.setInt(2, lowPrice);
            stmt.setInt(3, highPrice);

            ResultSet rs = stmt.executeQuery();
                    
            if(rs.next() == false)
            {
                displayMessage("There are no properties on record that match your criteria");
            }
            
            else
            {
                ViewProperties viewProperties = new ViewProperties(locationJTextField.getText(), lowPrice, highPrice);
                this.hide();
                viewProperties.show();
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
        JOptionPane.showMessageDialog(frame, message, "LIT Realty", JOptionPane.INFORMATION_MESSAGE);
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
            java.util.logging.Logger.getLogger(Search.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Search.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Search.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Search.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new Search().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton exitJBtn;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel locationJLabel;
    private javax.swing.JTextField locationJTextField;
    private javax.swing.JLabel loginTitleJLabel1;
    private javax.swing.JComboBox<String> priceRangeJComboBox;
    private javax.swing.JLabel priceRangeJLabel;
    private javax.swing.JButton searchJBtn;
    // End of variables declaration//GEN-END:variables
}
