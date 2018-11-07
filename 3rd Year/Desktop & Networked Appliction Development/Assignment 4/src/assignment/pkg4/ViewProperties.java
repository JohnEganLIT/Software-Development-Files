package assignment.pkg4;

import java.awt.Toolkit;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import static javax.swing.JOptionPane.YES_OPTION;

public class ViewProperties extends javax.swing.JFrame {
    
    private ResultSet properties;
    private Integer lowPrice;
    private Integer highPrice;
    private String search;
    
    public ViewProperties(String searchTerm, Integer low, Integer high) {
        initComponents();
        
        try{
            Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/litrealty", "root", "");

            String sql = "{ call SearchProperties(?,?,?) }";
            CallableStatement stmt = conn.prepareCall(sql);
            stmt.setString(1, searchTerm);
            stmt.setInt(2, low);
            stmt.setInt(3, high);

            ResultSet rs = stmt.executeQuery();

            properties = rs;
            properties.first();
            lowPrice =  low;
            highPrice = high;
            search = searchTerm;
            setValues();
            
        }
        catch (SQLException ex) 
        {
            displayMessage(ex.toString());
        }
    }
    
    public ViewProperties() {
        initComponents();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        streetJLabel = new javax.swing.JLabel();
        bedroomsJLabel = new javax.swing.JLabel();
        bathroomsJLabel = new javax.swing.JLabel();
        feetJLabel = new javax.swing.JLabel();
        descriptionJLabel = new javax.swing.JLabel();
        streetJTextField = new javax.swing.JTextField();
        bedroomsJTextField = new javax.swing.JTextField();
        bathroomsJTextField = new javax.swing.JTextField();
        feetJTextField = new javax.swing.JTextField();
        jScrollPane1 = new javax.swing.JScrollPane();
        descriptionJTextArea = new javax.swing.JTextArea();
        imageJLabel = new javax.swing.JLabel();
        priceJLabel = new javax.swing.JLabel();
        nextJBtn = new javax.swing.JButton();
        previousJBtn = new javax.swing.JButton();
        updateJBtn = new javax.swing.JButton();
        deleteJBtn = new javax.swing.JButton();
        cancelJBtn = new javax.swing.JButton();
        loginTitleJLabel1 = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        streetJLabel.setText("Street");

        bedroomsJLabel.setText("No. Of Bedrooms");

        bathroomsJLabel.setText("No. Of Bathrooms");

        feetJLabel.setText("Square Feet");

        descriptionJLabel.setText("Description");

        streetJTextField.setEditable(false);
        streetJTextField.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                streetJTextFieldMouseClicked(evt);
            }
        });

        bedroomsJTextField.setEditable(false);
        bedroomsJTextField.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                bedroomsJTextFieldMouseClicked(evt);
            }
        });
        bedroomsJTextField.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bedroomsJTextFieldActionPerformed(evt);
            }
        });

        bathroomsJTextField.setEditable(false);
        bathroomsJTextField.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                bathroomsJTextFieldMouseClicked(evt);
            }
        });

        feetJTextField.setEditable(false);
        feetJTextField.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                feetJTextFieldMouseClicked(evt);
            }
        });

        descriptionJTextArea.setEditable(false);
        descriptionJTextArea.setColumns(10);
        descriptionJTextArea.setLineWrap(true);
        descriptionJTextArea.setRows(5);
        descriptionJTextArea.setWrapStyleWord(true);
        descriptionJTextArea.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                descriptionJTextAreaMouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(descriptionJTextArea);

        imageJLabel.setText("Image Not Found!");

        priceJLabel.setText("jLabel7");

        nextJBtn.setText("Next");
        nextJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                nextJBtnActionPerformed(evt);
            }
        });

        previousJBtn.setText("Previous");
        previousJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                previousJBtnActionPerformed(evt);
            }
        });

        updateJBtn.setText("Update");
        updateJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                updateJBtnActionPerformed(evt);
            }
        });

        deleteJBtn.setText("Delete");
        deleteJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                deleteJBtnActionPerformed(evt);
            }
        });

        cancelJBtn.setText("Cancel");
        cancelJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cancelJBtnActionPerformed(evt);
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
                .addGap(37, 37, 37)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(loginTitleJLabel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addContainerGap())
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addGroup(layout.createSequentialGroup()
                                .addGap(0, 8, Short.MAX_VALUE)
                                .addComponent(previousJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 80, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(nextJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 80, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(updateJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 80, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(deleteJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 80, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(cancelJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 80, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                    .addGroup(layout.createSequentialGroup()
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(streetJLabel)
                                            .addComponent(bedroomsJLabel)
                                            .addComponent(bathroomsJLabel)
                                            .addComponent(feetJLabel))
                                        .addGap(37, 37, 37)
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                                            .addComponent(bathroomsJTextField, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 166, Short.MAX_VALUE)
                                            .addComponent(streetJTextField, javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(bedroomsJTextField, javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(feetJTextField, javax.swing.GroupLayout.Alignment.LEADING)))
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(descriptionJLabel)
                                        .addGap(18, 18, 18)
                                        .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 218, Short.MAX_VALUE)))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(imageJLabel)
                                    .addComponent(priceJLabel))))
                        .addGap(57, 57, 57))))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(loginTitleJLabel1)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(streetJLabel)
                    .addComponent(streetJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(bedroomsJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(bedroomsJLabel))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(bathroomsJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(bathroomsJLabel))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(feetJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(feetJLabel))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(descriptionJLabel)
                            .addComponent(jScrollPane1)))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(imageJLabel)
                        .addGap(51, 51, 51)
                        .addComponent(priceJLabel)))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(previousJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(updateJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(deleteJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(cancelJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(nextJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(41, 41, 41))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void bedroomsJTextFieldActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bedroomsJTextFieldActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_bedroomsJTextFieldActionPerformed

    private void nextJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_nextJBtnActionPerformed
        try {
            if(properties.isLast() == false)
            {
                properties.next();
                setValues(); 
            }
        } catch (SQLException ex) {    
           displayMessage(ex.toString());
        }         
    }//GEN-LAST:event_nextJBtnActionPerformed

    private void previousJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_previousJBtnActionPerformed
        try {
            if(properties.isFirst() == false)
            {
                properties.previous();
                setValues(); 
            }
        } catch (SQLException ex) {
       
           displayMessage(ex.toString());
        }
    }//GEN-LAST:event_previousJBtnActionPerformed

    private void updateJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_updateJBtnActionPerformed
        if(JOptionPane.showConfirmDialog(null, "Are you sure?") == YES_OPTION)
        {
            try {
            Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/litrealty", "root", "");
            
            String sql = "{ call UpdateProperty(?,?,?,?,?,?) }";
            CallableStatement stmt = conn.prepareCall(sql);
            stmt.setString(1, properties.getString("id")); 
            stmt.setString(2, streetJTextField.getText()); 
            stmt.setString(3, bedroomsJTextField.getText()); 
            stmt.setString(4, bathroomsJTextField.getText()); 
            stmt.setString(5, feetJTextField.getText()); 
            stmt.setString(6, descriptionJTextArea.getText()); 
                   
            stmt.executeQuery();
      
            ViewProperties viewProperties = new ViewProperties(search, lowPrice, highPrice);
            this.dispose();
            viewProperties.show();
          
            displayMessage("Property Updated");
                   
        } catch (SQLException ex) {
            Logger.getLogger(ViewProperties.class.getName()).log(Level.SEVERE, null, ex);
        }
        }      
    }//GEN-LAST:event_updateJBtnActionPerformed

    private void streetJTextFieldMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_streetJTextFieldMouseClicked
        streetJTextField.setEditable(true);
    }//GEN-LAST:event_streetJTextFieldMouseClicked

    private void bedroomsJTextFieldMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_bedroomsJTextFieldMouseClicked
        bedroomsJTextField.setEditable(true);
    }//GEN-LAST:event_bedroomsJTextFieldMouseClicked

    private void bathroomsJTextFieldMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_bathroomsJTextFieldMouseClicked
        bathroomsJTextField.setEditable(true);
    }//GEN-LAST:event_bathroomsJTextFieldMouseClicked

    private void feetJTextFieldMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_feetJTextFieldMouseClicked
        feetJTextField.setEditable(true);
    }//GEN-LAST:event_feetJTextFieldMouseClicked

    private void descriptionJTextAreaMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_descriptionJTextAreaMouseClicked
        descriptionJTextArea.setEditable(true);
    }//GEN-LAST:event_descriptionJTextAreaMouseClicked

    private void deleteJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_deleteJBtnActionPerformed
        
        if(JOptionPane.showConfirmDialog(null, "Are you sure?") == YES_OPTION)
        {
            try {
            Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/litrealty", "root", "");
            
            String sql = "{ call DeleteProperty(?) }";
            CallableStatement stmt = conn.prepareCall(sql);
            stmt.setString(1, properties.getString("id"));          
            stmt.executeQuery();
      
            ViewProperties viewProperties = new ViewProperties(search, lowPrice, highPrice);
            this.dispose();
            viewProperties.show();
          
            displayMessage("Property Deleted");
                   
        } catch (SQLException ex) {
            Logger.getLogger(ViewProperties.class.getName()).log(Level.SEVERE, null, ex);
        }
        }      
    }//GEN-LAST:event_deleteJBtnActionPerformed

    private void cancelJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cancelJBtnActionPerformed
        Search search = new Search();
        this.dispose();
        search.show();
    }//GEN-LAST:event_cancelJBtnActionPerformed
    
    private void setValues()
    {
        try {
            streetJTextField.setText(properties.getString("street"));
            bedroomsJTextField.setText(properties.getString("bedrooms"));
            bathroomsJTextField.setText(properties.getString("bathrooms"));
            feetJTextField.setText(properties.getString("squarefeet"));
            descriptionJTextArea.setText(properties.getString("description"));
            priceJLabel.setText("€" + properties.getString("price"));

            imageJLabel.setText("");         
            imageJLabel.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Images/thumbnails/" + properties.getString("photo"))));
        } 
        
        catch (SQLException ex) {
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
            java.util.logging.Logger.getLogger(ViewProperties.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(ViewProperties.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(ViewProperties.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(ViewProperties.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                 new ViewProperties().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel bathroomsJLabel;
    private javax.swing.JTextField bathroomsJTextField;
    private javax.swing.JLabel bedroomsJLabel;
    private javax.swing.JTextField bedroomsJTextField;
    private javax.swing.JButton cancelJBtn;
    private javax.swing.JButton deleteJBtn;
    private javax.swing.JLabel descriptionJLabel;
    private javax.swing.JTextArea descriptionJTextArea;
    private javax.swing.JLabel feetJLabel;
    private javax.swing.JTextField feetJTextField;
    private javax.swing.JLabel imageJLabel;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JLabel loginTitleJLabel1;
    private javax.swing.JButton nextJBtn;
    private javax.swing.JButton previousJBtn;
    private javax.swing.JLabel priceJLabel;
    private javax.swing.JLabel streetJLabel;
    private javax.swing.JTextField streetJTextField;
    private javax.swing.JButton updateJBtn;
    // End of variables declaration//GEN-END:variables
}
