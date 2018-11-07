package assignment.pkg3;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Random;
import javax.swing.*;
import static jdk.nashorn.internal.objects.NativeString.substring;

public class MainJFrame extends javax.swing.JFrame 
{
    //Create Array List
    ArrayList<Parcel> parcelList = new ArrayList();
    
    //List model for packageJList
    DefaultListModel listModel = new DefaultListModel();
    
    //Currently selected list value
    String selected;  
    
    //Localised Text
    String parcelAddedMsg;
    String parcelUpdatedMsg;
    String parcelRemoveMsg;
    String selectOptionTitle;
    String nameValidationMsg;
    String addressValidationMsg;
    String cityValidationMsg;
    String descValidationMsg;
    String countyValidationMsg;
    String contactNumValidationMsg;
    String priceNumValidationMsg;
    String priceValidationMsg;
    String prepaidValidationMsg;
    String messageTitle;
    String selectCounty;
    String parcelDisplayErrorMsg;
    String AllCountyComboBox;
    
    public MainJFrame(String language)
    {     
        initComponents();
        
        //Disables
        addJBtn.setEnabled(false);
        removeJBtn.setEnabled(false);
        editJBtn.setEnabled(false);     
        updateJBtn.setEnabled(false);
        backJBtn.setEnabled(false);
        nextJBtn.setEnabled(false);
        
        localisation(language);
        
    }
    
    private void localisation(String language)
    {
        switch(language)
        {
            case "English":
                parcelAddedMsg = "Parcel added";
                parcelUpdatedMsg = "Parcel updated";
                parcelRemoveMsg = "Are you sure you want to delete this parcel?";
                selectOptionTitle = "Select An Option";
                nameValidationMsg = "A name must be entered!";
                addressValidationMsg = "An address must be entered!";
                cityValidationMsg = "A city must be entered!";
                countyValidationMsg = "A county must be selected!";
                contactNumValidationMsg = "A contact number must be entered!";
                priceNumValidationMsg = "Price must be a number!";
                priceValidationMsg = "A price must be entered!";
                prepaidValidationMsg = "Prepaid Yes/No Must Be Selected!";
                messageTitle = "Message";
                selectCounty = "Select County";
                parcelDisplayErrorMsg = "Error Displaying Parcel";
                AllCountyComboBox = "All";
                
            break;
            
            case "French":
                parcelAddedMsg = "Colis ajouté";
                parcelUpdatedMsg = "Parcel mis à jour";
                parcelRemoveMsg = "Voulez-vous vraiment supprimer ce colis?";
                selectOptionTitle = "Choisir une option";
                addJBtn.setText("Ajouter");
                parcelIDJlabel.setText("ID de colis");
                scanJBtn.setText("Balayage");
                removeJBtn.setText("retirer");
                editJBtn.setText("Modifier");
                updateJBtn.setText("Mettre à jour");
                backJBtn.setText("Arrière");
                nextJBtn.setText("Prochain");
                displayAllJBtn.setText("Afficher tout");
                arrivalJLabel.setText("Arrivée à");
                nameJLabel.setText("Prénom");
                addressJLabel.setText("Adresse");
                cityJLabel.setText("ville");
                countyJLabel.setText("comté");
                contactNumJLabel.setText("numéro de contact");
                descJLabel.setText("la description");
                priceJLabel.setText("prix");
                prepaidJLabel.setText("prépayé");
                totalParcelsJLabel.setText("Nombre total de colis");  
                nameValidationMsg = "Un nom doit être entré!";
                addressValidationMsg = "Une adresse doit être entrée!";
                cityValidationMsg = "Une ville doit être entrée!";
                countyValidationMsg = "Un comté doit être sélectionné!";
                contactNumValidationMsg = "Un numéro de contact doit être entré!";
                priceNumValidationMsg = "Le prix doit être un nombre!";
                priceValidationMsg = "Le prix doit être un nombre!";
                prepaidValidationMsg = "Prépayé Oui / Non doit être sélectionné!";
                messageTitle = "Message";
                selectCounty = "Sélectionner le comté";
                countyJComboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Sélectionner le comté", "Antrim", "Armagh", "Carlow", "Cavan", "Clare", "Cork", "Derry", "Donegal", "Down", "Dublin", "Fermanagh", "Galway", "Kerry", "Kildare", "Kilkenny", "Laois", "Leitrim", "Limerick", "Longford", "Louth", "Mayo", "Meath", "Monaghan", "Offaly", "Roscommon", "Sligo", "Tipperary", "Tyrone", "Waterford", "Westmeath", "Wexford", "Wicklow" }));
                parcelsByCountyJComboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Tout", "Antrim", "Armagh", "Carlow", "Cavan", "Clare", "Cork", "Derry", "Donegal", "Down", "Dublin", "Fermanagh", "Galway", "Kerry", "Kildare", "Kilkenny", "Laois", "Leitrim", "Limerick", "Longford", "Louth", "Mayo", "Meath", "Monaghan", "Offaly", "Roscommon", "Sligo", "Tipperary", "Tyrone", "Waterford", "Westmeath", "Wexford", "Wicklow" }));
                parcelDisplayErrorMsg = "Erreur lors de l'affichage de la parcelle";
                AllCountyComboBox = "Tout";
                jRadioBtnYes.setText("Oui");
                jRadioBtnNo.setText("Non");
            break;      
            
            case "German":
                parcelAddedMsg = "Hinzugefügt Paket";
                parcelUpdatedMsg = "Parcel aktualisiert";
                parcelRemoveMsg = "Wollen Sie wirklich dieses Paket zu löschen?";
                selectOptionTitle = "Wählen Sie eine Option";
                addJBtn.setText("Ajouter");
                parcelIDJlabel.setText("hinzufügen");
                scanJBtn.setText("Scan");
                removeJBtn.setText("zurückziehen");
                editJBtn.setText("Veränderung");
                updateJBtn.setText("Mettre à jour");
                backJBtn.setText("Aktualisierung");
                nextJBtn.setText("nächste");
                displayAllJBtn.setText("alle");
                arrivalJLabel.setText("ankommen");
                nameJLabel.setText("Vorname");
                addressJLabel.setText("Adresse");
                cityJLabel.setText("Adresse");
                countyJLabel.setText("comté");
                contactNumJLabel.setText("Grafschaft");
                descJLabel.setText("Beschreibung");
                priceJLabel.setText("Preis");
                prepaidJLabel.setText("vorausbezahlt");
                totalParcelsJLabel.setText("Gesamtzahl der Pakete");  
                nameValidationMsg = "Ein Name muss eingegeben werden!";
                addressValidationMsg = "Eine Adresse muss eingegeben werden!";
                cityValidationMsg = "Eine Stadt muss eingegeben werden!";
                countyValidationMsg = "Ein Landkreis muss ausgewählt werden!";
                contactNumValidationMsg = "Eine Telefonnummer eingegeben werden muss!";
                priceNumValidationMsg = "Preis muss eine Zahl sein!";
                priceValidationMsg = "Der Preis muss eine Zahl sein!";
                prepaidValidationMsg = "Prepaid Ja / Nein zu wählen!";
                messageTitle = "Nachricht";
                selectCounty = "Wählen Sie Landkreis";
                countyJComboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Wählen Sie Landkreis", "Antrim", "Armagh", "Carlow", "Cavan", "Clare", "Cork", "Derry", "Donegal", "Down", "Dublin", "Fermanagh", "Galway", "Kerry", "Kildare", "Kilkenny", "Laois", "Leitrim", "Limerick", "Longford", "Louth", "Mayo", "Meath", "Monaghan", "Offaly", "Roscommon", "Sligo", "Tipperary", "Tyrone", "Waterford", "Westmeath", "Wexford", "Wicklow" }));
                parcelsByCountyJComboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Alle", "Antrim", "Armagh", "Carlow", "Cavan", "Clare", "Cork", "Derry", "Donegal", "Down", "Dublin", "Fermanagh", "Galway", "Kerry", "Kildare", "Kilkenny", "Laois", "Leitrim", "Limerick", "Longford", "Louth", "Mayo", "Meath", "Monaghan", "Offaly", "Roscommon", "Sligo", "Tipperary", "Tyrone", "Waterford", "Westmeath", "Wexford", "Wicklow" }));
                parcelDisplayErrorMsg = "Erreur lors de l'affichage de la parcelle";
                AllCountyComboBox = "Alle";
                jRadioBtnYes.setText("Ja");
                jRadioBtnNo.setText("Nicht");
            break;   
    
            
        }         
    }
    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        buttonGroup1 = new javax.swing.ButtonGroup();
        jSeparator3 = new javax.swing.JSeparator();
        jPanel1 = new javax.swing.JPanel();
        arrivalJLabel = new javax.swing.JLabel();
        parcelIDJlabel = new javax.swing.JLabel();
        nameJLabel = new javax.swing.JLabel();
        addressJLabel = new javax.swing.JLabel();
        cityJLabel = new javax.swing.JLabel();
        descJLabel = new javax.swing.JLabel();
        priceJLabel = new javax.swing.JLabel();
        countyJLabel = new javax.swing.JLabel();
        contactNumJLabel = new javax.swing.JLabel();
        prepaidJLabel = new javax.swing.JLabel();
        jRadioBtnYes = new javax.swing.JRadioButton();
        jRadioBtnNo = new javax.swing.JRadioButton();
        countyJComboBox = new javax.swing.JComboBox<>();
        arrivalJTextField = new javax.swing.JTextField();
        parcelIDJTextField = new javax.swing.JTextField();
        nameJTextField = new javax.swing.JTextField();
        descJTextField = new javax.swing.JTextField();
        addressJTextField = new javax.swing.JTextField();
        cityJTextField = new javax.swing.JTextField();
        contactNumJTextField = new javax.swing.JTextField();
        priceJTextField = new javax.swing.JTextField();
        jSeparator1 = new javax.swing.JSeparator();
        jLabel1 = new javax.swing.JLabel();
        jSeparator2 = new javax.swing.JSeparator();
        jSeparator4 = new javax.swing.JSeparator();
        jSeparator5 = new javax.swing.JSeparator();
        parcelsByCountyJComboBox = new javax.swing.JComboBox<>();
        scanJBtn = new javax.swing.JButton();
        addJBtn = new javax.swing.JButton();
        removeJBtn = new javax.swing.JButton();
        editJBtn = new javax.swing.JButton();
        displayAllJBtn = new javax.swing.JButton();
        jScrollPane2 = new javax.swing.JScrollPane();
        parcelJList = new javax.swing.JList<>();
        updateJBtn = new javax.swing.JButton();
        backJBtn = new javax.swing.JButton();
        nextJBtn = new javax.swing.JButton();
        totalParcelsJLabel = new javax.swing.JLabel();
        totalParcelsJTextField = new javax.swing.JTextField();

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 100, Short.MAX_VALUE)
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 100, Short.MAX_VALUE)
        );

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setLocation(new java.awt.Point(300, 300));
        setMaximumSize(new java.awt.Dimension(873, 330));
        setMinimumSize(new java.awt.Dimension(873, 330));
        setResizable(false);

        arrivalJLabel.setText("Arrived at:");

        parcelIDJlabel.setText("Parcel ID:");

        nameJLabel.setText("Name:");

        addressJLabel.setText("Address:");

        cityJLabel.setText("City:");

        descJLabel.setText("Description:");

        priceJLabel.setText("Price:");

        countyJLabel.setText("County:");

        contactNumJLabel.setText("Contact Num:");

        prepaidJLabel.setText("Prepaid:");

        jRadioBtnYes.setBackground(new java.awt.Color(255, 255, 255));
        buttonGroup1.add(jRadioBtnYes);
        jRadioBtnYes.setText("YES");
        jRadioBtnYes.setEnabled(false);

        jRadioBtnNo.setBackground(new java.awt.Color(255, 255, 255));
        buttonGroup1.add(jRadioBtnNo);
        jRadioBtnNo.setText("NO");
        jRadioBtnNo.setEnabled(false);

        countyJComboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Select County", "Antrim", "Armagh", "Carlow", "Cavan", "Clare", "Cork", "Derry", "Donegal", "Down", "Dublin", "Fermanagh", "Galway", "Kerry", "Kildare", "Kilkenny", "Laois", "Leitrim", "Limerick", "Longford", "Louth", "Mayo", "Meath", "Monaghan", "Offaly", "Roscommon", "Sligo", "Tipperary", "Tyrone", "Waterford", "Westmeath", "Wexford", "Wicklow" }));
        countyJComboBox.setEnabled(false);
        countyJComboBox.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                countyJComboBoxActionPerformed(evt);
            }
        });

        arrivalJTextField.setEditable(false);
        arrivalJTextField.setBackground(new java.awt.Color(255, 255, 255));
        arrivalJTextField.setDisabledTextColor(new java.awt.Color(0, 0, 0));
        arrivalJTextField.setEnabled(false);

        parcelIDJTextField.setEditable(false);
        parcelIDJTextField.setBackground(new java.awt.Color(255, 255, 255));
        parcelIDJTextField.setDisabledTextColor(new java.awt.Color(0, 0, 0));
        parcelIDJTextField.setEnabled(false);

        nameJTextField.setDisabledTextColor(new java.awt.Color(0, 0, 0));
        nameJTextField.setEnabled(false);

        descJTextField.setDisabledTextColor(new java.awt.Color(0, 0, 0));
        descJTextField.setEnabled(false);

        addressJTextField.setDisabledTextColor(new java.awt.Color(0, 0, 0));
        addressJTextField.setEnabled(false);

        cityJTextField.setDisabledTextColor(new java.awt.Color(0, 0, 0));
        cityJTextField.setEnabled(false);

        contactNumJTextField.setDisabledTextColor(new java.awt.Color(0, 0, 0));
        contactNumJTextField.setEnabled(false);

        priceJTextField.setDisabledTextColor(new java.awt.Color(0, 0, 0));
        priceJTextField.setEnabled(false);

        jLabel1.setText("Parcel Information");

        jSeparator5.setOrientation(javax.swing.SwingConstants.VERTICAL);

        parcelsByCountyJComboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "All", "Antrim", "Armagh", "Carlow", "Cavan", "Clare", "Cork", "Derry", "Donegal", "Down", "Dublin", "Fermanagh", "Galway", "Kerry", "Kildare", "Kilkenny", "Laois", "Leitrim", "Limerick", "Longford", "Louth", "Mayo", "Meath", "Monaghan", "Offaly", "Roscommon", "Sligo", "Tipperary", "Tyrone", "Waterford", "Westmeath", "Wexford", "Wicklow" }));
        parcelsByCountyJComboBox.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                parcelsByCountyJComboBoxActionPerformed(evt);
            }
        });

        scanJBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/assignment/pkg3/icons/scan.gif"))); // NOI18N
        scanJBtn.setMnemonic('S');
        scanJBtn.setText("Scan Now");
        scanJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                scanJBtnActionPerformed(evt);
            }
        });

        addJBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/assignment/pkg3/icons/add.gif"))); // NOI18N
        addJBtn.setMnemonic('A');
        addJBtn.setText("Add");
        addJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                addJBtnActionPerformed(evt);
            }
        });

        removeJBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/assignment/pkg3/icons/remove.gif"))); // NOI18N
        removeJBtn.setMnemonic('R');
        removeJBtn.setText("Remove");
        removeJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                removeJBtnActionPerformed(evt);
            }
        });

        editJBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/assignment/pkg3/icons/edit.gif"))); // NOI18N
        editJBtn.setMnemonic('E');
        editJBtn.setText("Edit");
        editJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                editJBtnActionPerformed(evt);
            }
        });

        displayAllJBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/assignment/pkg3/icons/displayAll.gif"))); // NOI18N
        displayAllJBtn.setMnemonic('D');
        displayAllJBtn.setText("Display All");
        displayAllJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                displayAllJBtnActionPerformed(evt);
            }
        });

        parcelJList.setSelectionMode(javax.swing.ListSelectionModel.SINGLE_SELECTION);
        parcelJList.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                parcelJListMouseClicked(evt);
            }
        });
        jScrollPane2.setViewportView(parcelJList);

        updateJBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/assignment/pkg3/icons/update.gif"))); // NOI18N
        updateJBtn.setMnemonic('U');
        updateJBtn.setText("Update");
        updateJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                updateJBtnActionPerformed(evt);
            }
        });

        backJBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/assignment/pkg3/icons/back.gif"))); // NOI18N
        backJBtn.setMnemonic('B');
        backJBtn.setText("Back");
        backJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                backJBtnActionPerformed(evt);
            }
        });

        nextJBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/assignment/pkg3/icons/next.gif"))); // NOI18N
        nextJBtn.setMnemonic('N');
        nextJBtn.setText("Next");
        nextJBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                nextJBtnActionPerformed(evt);
            }
        });

        totalParcelsJLabel.setText("Total Number of Parcels: ");

        totalParcelsJTextField.setEditable(false);
        totalParcelsJTextField.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        totalParcelsJTextField.setHorizontalAlignment(javax.swing.JTextField.CENTER);
        totalParcelsJTextField.setText("0");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jSeparator4)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(scanJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(addJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(removeJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(editJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(updateJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(backJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(nextJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(displayAllJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(parcelIDJlabel)
                                    .addComponent(nameJLabel)
                                    .addComponent(addressJLabel)
                                    .addComponent(cityJLabel)
                                    .addComponent(descJLabel))
                                .addGap(5, 5, 5)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addGroup(layout.createSequentialGroup()
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                            .addGroup(layout.createSequentialGroup()
                                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                                                    .addGroup(layout.createSequentialGroup()
                                                        .addComponent(priceJTextField)
                                                        .addGap(18, 18, 18)
                                                        .addComponent(prepaidJLabel)
                                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                                        .addComponent(jRadioBtnYes)
                                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                        .addComponent(jRadioBtnNo)
                                                        .addGap(80, 80, 80))
                                                    .addGroup(layout.createSequentialGroup()
                                                        .addComponent(cityJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 86, javax.swing.GroupLayout.PREFERRED_SIZE)
                                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                        .addComponent(countyJLabel)
                                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                        .addComponent(countyJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, 108, javax.swing.GroupLayout.PREFERRED_SIZE)
                                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                        .addComponent(contactNumJLabel, javax.swing.GroupLayout.PREFERRED_SIZE, 87, javax.swing.GroupLayout.PREFERRED_SIZE)
                                                        .addGap(1, 1, 1)))
                                                .addComponent(contactNumJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 124, javax.swing.GroupLayout.PREFERRED_SIZE))
                                            .addComponent(addressJTextField)
                                            .addComponent(descJTextField))
                                        .addGap(0, 0, Short.MAX_VALUE))
                                    .addGroup(layout.createSequentialGroup()
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                                            .addComponent(parcelIDJTextField, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 457, Short.MAX_VALUE)
                                            .addComponent(nameJTextField, javax.swing.GroupLayout.Alignment.LEADING))
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))))
                            .addGroup(layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(priceJLabel)
                                        .addGap(278, 278, 278)
                                        .addComponent(jSeparator5, javax.swing.GroupLayout.PREFERRED_SIZE, 50, javax.swing.GroupLayout.PREFERRED_SIZE))
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(arrivalJLabel)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(arrivalJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 114, javax.swing.GroupLayout.PREFERRED_SIZE))
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(jSeparator2, javax.swing.GroupLayout.PREFERRED_SIZE, 14, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(jLabel1)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, 409, javax.swing.GroupLayout.PREFERRED_SIZE)))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)))
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(totalParcelsJLabel)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(totalParcelsJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 23, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addComponent(parcelsByCountyJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, 445, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 445, javax.swing.GroupLayout.PREFERRED_SIZE))))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addContainerGap()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(totalParcelsJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(totalParcelsJLabel))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(parcelsByCountyJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(11, 11, 11)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(arrivalJLabel)
                            .addComponent(arrivalJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, 10, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jSeparator2, javax.swing.GroupLayout.PREFERRED_SIZE, 10, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 16, javax.swing.GroupLayout.PREFERRED_SIZE))))
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(44, 44, 44)
                        .addComponent(jSeparator5, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(14, 14, 14)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(parcelIDJlabel)
                            .addComponent(parcelIDJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(nameJLabel)
                            .addComponent(nameJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(addressJLabel)
                            .addComponent(addressJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(cityJLabel)
                            .addComponent(cityJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(countyJLabel)
                            .addComponent(contactNumJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(countyJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, 20, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(contactNumJLabel))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(descJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(descJLabel))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(priceJLabel)
                            .addComponent(priceJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(prepaidJLabel)
                            .addComponent(jRadioBtnYes)
                            .addComponent(jRadioBtnNo)))
                    .addGroup(layout.createSequentialGroup()
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 193, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jSeparator4, javax.swing.GroupLayout.PREFERRED_SIZE, 10, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(scanJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(addJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(removeJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(editJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(displayAllJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(updateJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(backJBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(nextJBtn, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void countyJComboBoxActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_countyJComboBoxActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_countyJComboBoxActionPerformed

    private void addJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_addJBtnActionPerformed
        addParcel(parcelAddedMsg); //Adds parcel to parcelList array list
    }//GEN-LAST:event_addJBtnActionPerformed

    private void scanJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_scanJBtnActionPerformed
        scanParcel(); //Scans new parcel. Creates delivery timestamp and generates a parcelID
    }//GEN-LAST:event_scanJBtnActionPerformed

    private void parcelJListMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_parcelJListMouseClicked
        checkIfItemSelected();     
    }//GEN-LAST:event_parcelJListMouseClicked

    private void removeJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_removeJBtnActionPerformed
        removeParcel(); //Deletes parcel from parcelList array
    }//GEN-LAST:event_removeJBtnActionPerformed

    private void editJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_editJBtnActionPerformed
        editParcel();
    }//GEN-LAST:event_editJBtnActionPerformed

    private void displayAllJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_displayAllJBtnActionPerformed
        displayAllParcels();
    }//GEN-LAST:event_displayAllJBtnActionPerformed

    private void parcelsByCountyJComboBoxActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_parcelsByCountyJComboBoxActionPerformed
        clearFields();
        filterList();
        checkIfItemSelected();
    }//GEN-LAST:event_parcelsByCountyJComboBoxActionPerformed

    private void updateJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_updateJBtnActionPerformed
        updateParcel();
    }//GEN-LAST:event_updateJBtnActionPerformed

    private void nextJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_nextJBtnActionPerformed
        int index = parcelJList.getSelectedIndex();
        if(!parcelJList.isSelectionEmpty())
        {
            parcelJList.setSelectedIndex(index + 1);
            setSelectedValue();     
            displayParcel();
        }
    }//GEN-LAST:event_nextJBtnActionPerformed

    private void backJBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_backJBtnActionPerformed
        int index = parcelJList.getSelectedIndex();
        
        if(!parcelJList.isSelectionEmpty())
        {
            parcelJList.setSelectedIndex(index - 1);
            setSelectedValue();
            displayParcel();
        }     
    }//GEN-LAST:event_backJBtnActionPerformed
    
    private void scanParcel()
    {
        //Enables
        addJBtn.setEnabled(true);
        
        //Disables
        scanJBtn.setEnabled(false);
        removeJBtn.setEnabled(false);
        editJBtn.setEnabled(false);     
        updateJBtn.setEnabled(false);
        backJBtn.setEnabled(false);
        nextJBtn.setEnabled(false);
        parcelJList.setEnabled(false);
        parcelsByCountyJComboBox.setEnabled(false);
                
        //Makes fields editable 
        unlockFields();
        
        //Deselects item from parcelJList
        parcelJList.clearSelection();
        
        //Clears form fields
        clearFields();
        
        //Gets current date and time for Arrived At field
        DateFormat arrivalDateFormat = new SimpleDateFormat("kk:mm  dd/MM/YYYY");
        Date arrivalDate = new Date();
        arrivalJTextField.setText(arrivalDateFormat.format(arrivalDate));
        
        //Creates random number of length 4 for parcelID
        Random rnd = new Random();
        int n = 1000 + rnd.nextInt(9000);
        
        //Gets the milliseconds from the current time to further randomise parcelID
        DateFormat dateFormat = new SimpleDateFormat("ssSSS");
        Date date = new Date();
            
        //Concatonates random number and time milliseconds to make parcelID
        String parcelID = Integer.toString(n) + dateFormat.format(date);
        parcelIDJTextField.setText(parcelID);       
    }
    
    private void addParcel(String message)
    {           
        Parcel parcel1 = new Parcel("47836587346", "89734589");
        
        parcel1.setName("Big fat parcel");
        
        Parcel parcel2 = new Parcel("43523452","34252345");
        parcel2.setName("dfksdfh");
        
        Parcel parcel3 = new Parcel("", "");
        parcel3.setName("dsfjksdhf");
        
        Parcel[] parcelArray = new Parcel[20];
        
        parcelArray[0] = parcel1;
        parcelArray[1] = parcel2;
        
        
        parcelArray[1].getName();
                
        //Creates variables from entered field values
        String parcelID = parcelIDJTextField.getText();
        String arrivalTime = arrivalJTextField.getText();
        String name = nameJTextField.getText();
        String address = addressJTextField.getText();
        String city = cityJTextField.getText();
        String county = countyJComboBox.getSelectedItem().toString();
        String contactNumber = contactNumJTextField.getText();
        String description = descJTextField.getText();
        Double price;
        Boolean prePaid;
        
        //Checks if entered price is a number
        if(checkIfNum(priceJTextField.getText()) && !priceJTextField.getText().isEmpty()) 
            price = Double.parseDouble(priceJTextField.getText());       
        else
            price = -1.0; 
        
        //Checks if the Yes or No radio button has been selected
        if(jRadioBtnYes.isSelected()) 
            prePaid = true;
        else if(jRadioBtnNo.isSelected())
            prePaid = false;         
        else   
            prePaid = null;      
        
        //If statements checks that all fields are filled
        if(name.isEmpty())
            displayMessage(nameValidationMsg); 
        else if(address.isEmpty())
            displayMessage(addressValidationMsg); 
        else if(city.isEmpty())
            displayMessage(cityValidationMsg); 
        else if(county.equals(selectCounty))
            displayMessage(countyValidationMsg); 
        else if(contactNumber.isEmpty())
            displayMessage(contactNumValidationMsg);
        else if(prePaid == null)
            displayMessage(prepaidValidationMsg); 
        else if(price == -1.0)
            displayMessage(priceNumValidationMsg); 
        else if(priceJTextField.getText().isEmpty())
            displayMessage(priceValidationMsg); 
        else
        {
            //Creates instance of Parcel class
            Parcel parcel = new Parcel(parcelID, arrivalTime); 

            //Calls Parcel class contructor 
            parcel.setParcel(name, address, city, county, contactNumber, arrivalTime, description, price, prePaid);

            //Sets selected to current Parcel
            selected = parcel.getParcelID();
                
            //Checks if parcelID already exists. Returning -1 means the parcel does not exists
            if(searchParcelList() == -1)
            {   
                //Adds new parcel to parcelList arrayList 
                parcelList.add(parcel); 

                //Updates parcelJList
                displayParcelList(); 

                //Makes fields uneditable
                lockFields(); 

                //Clears form fields
                clearFields(); 
                
                //Enables
                scanJBtn.setEnabled(true);         
                parcelJList.setEnabled(true);
                parcelsByCountyJComboBox.setEnabled(true);
                
                //Disables
                addJBtn.setEnabled(false);
                            
                //Gets size of parcelList array and sets it to totalParcelsJTextField value
                totalParcelsJTextField.setText(Integer.toString(parcelList.size()));
                
                displayMessage(message);
            }
            
            else
            {
                displayMessage("Parcel already exists!");
            } 
        }            
    }
    
    private void editParcel()
    {
        unlockFields();
        scanJBtn.setEnabled(false);
        addJBtn.setEnabled(false);
        removeJBtn.setEnabled(false);
        editJBtn.setEnabled(false);
        parcelJList.setEnabled(false);
        parcelsByCountyJComboBox.setEnabled(false);
        updateJBtn.setEnabled(true);
        nextJBtn.setEnabled(false);
        backJBtn.setEnabled(false);
        
    }
    
    private void updateParcel()
    {
        int index = searchParcelList();

        parcelList.remove(index);

        scanJBtn.setEnabled(true);
        addJBtn.setEnabled(true);
        removeJBtn.setEnabled(true);
        editJBtn.setEnabled(true);
        parcelJList.setEnabled(true);
        parcelsByCountyJComboBox.setEnabled(true);
        editJBtn.setEnabled(false);
        updateJBtn.setEnabled(false);
        removeJBtn.setEnabled(false);
        
        addParcel(parcelUpdatedMsg);
       
        
        clearFields();    
    }
    
    private void removeParcel()
    {     
        int dialogButton = JOptionPane.YES_NO_OPTION;
        int dialogResult = JOptionPane.showConfirmDialog (null, parcelRemoveMsg, selectOptionTitle, dialogButton);
        if(dialogResult == JOptionPane.YES_OPTION)
        {
            int index = searchParcelList();
            parcelList.remove(index);
            clearFields();
            removeJBtn.setEnabled(false);
            editJBtn.setEnabled(false);
            displayParcelList();
        }   
        
        //Gets size of parcelList array and sets it to totalParcelsJTextField value
        totalParcelsJTextField.setText(Integer.toString(parcelList.size()));
    }
    
    private void displayParcelList()
    {                   
        listModel.removeAllElements();
        
        for(int i=0; i<parcelList.size(); i++)
        {
            Parcel currentParcel = parcelList.get(i);
            
            listModel.addElement(currentParcel.getParcelID() + "   " + currentParcel.getName() + "   " + currentParcel.getDescription());        
        }
            
        parcelJList.setModel(listModel);
    }
    
    private void displayParcel()
    {               
        int index = searchParcelList();
        
        if(index != -1)
        {
            Parcel parcel = parcelList.get(index);
            
            parcelIDJTextField.setText(parcel.getParcelID());
            arrivalJTextField.setText(parcel.getArrivalTime());
            nameJTextField.setText(parcel.getName()); 
            addressJTextField.setText(parcel.getAddress());
            cityJTextField.setText(parcel.getCity()); 
            countyJComboBox.setSelectedItem(parcel.getCounty());
            contactNumJTextField.setText(parcel.getContactNumber());
            descJTextField.setText(parcel.getDescription());
            priceJTextField.setText(Double.toString(parcel.getPrice()));
            if(parcel.isPrePaid())
                jRadioBtnYes.setSelected(true);
            else
                jRadioBtnNo.setSelected(true);
        }
        
        else 
        {
            displayMessage(parcelDisplayErrorMsg);
        }
    }
    
    private void clearFields()
    {
        parcelIDJTextField.setText("");
        arrivalJTextField.setText("");
        nameJTextField.setText(""); 
        addressJTextField.setText("");
        cityJTextField.setText(""); 
        countyJComboBox.setSelectedItem("Select County");
        contactNumJTextField.setText("");
        descJTextField.setText("");
        priceJTextField.setText("");    
        
        buttonGroup1.clearSelection();
    }
    
    private void checkIfItemSelected()
    {         
        if(parcelJList.isSelectionEmpty())   
        {
            editJBtn.setEnabled(false);
            removeJBtn.setEnabled(false);
            backJBtn.setEnabled(false);
            nextJBtn.setEnabled(false);
        }
            
        else
        {
            setSelectedValue();
            editJBtn.setEnabled(true);
            removeJBtn.setEnabled(true);
            backJBtn.setEnabled(true);
            nextJBtn.setEnabled(true);
            displayParcel(); //Displays the selected parcel in the form fields
        }     
    }
    
    private int searchParcelList()
    {   
        for(Parcel item : parcelList)
        {
            if(item.getParcelID().equals(selected))
            {
                return parcelList.indexOf(item);
            }
        }
        return -1;
    }
    
    private void setSelectedValue()
    {
        selected = substring(parcelJList.getSelectedValue(),0,9); //Changes selected value to clicked list value
    }
    
    private void filterList()
    {   
        listModel.removeAllElements();
        
        for(int i=0; i<parcelList.size(); i++)
        {
            Parcel currentParcel = parcelList.get(i);
            
            if(currentParcel.getCounty().equals(parcelsByCountyJComboBox.getSelectedItem()))
                listModel.addElement(currentParcel.getParcelID());  
            
            else if(parcelsByCountyJComboBox.getSelectedItem().equals(AllCountyComboBox))
                listModel.addElement(currentParcel.getParcelID());        
        }
            
        parcelJList.setModel(listModel);
        
    }
    
    private void displayAllParcels()
    {
        JDialog dialog = new JDialog();
        dialog.setSize(500,500);
        dialog.setLocation(300, 300);
        JTextArea textArea = new JTextArea();
        textArea.setBounds(10,10,40,20);
        
        for(Parcel item : parcelList)
        {
            String prepaid;
            if(item.isPrePaid() == true)
                prepaid = "Yes";
            else
                prepaid = "No";
            
            textArea.append(item.getParcelID() + " " + item.getArrivalTime() + " " + item.getName() + " " + item.getAddress() + " " + item.getCity() + " " + item.getDescription() + " " + item.getPrice() + " " + "Prepaid = " + " " + item.getContactNumber() + " " + prepaid + "\n");
        }
        
        dialog.add(textArea);
        dialog.setVisible(true);
    }
    
    private void displayMessage(String message)
    {
        JFrame frame = new JFrame();
        //frame.setTitle("dhfakjlsdhfkldshf");
        //JOptionPane.setTitle(messageTitle);
        JOptionPane.showMessageDialog(frame, message, messageTitle, JOptionPane.INFORMATION_MESSAGE);
    }
    
    private void unlockFields()
    {
        nameJTextField.setEnabled(true);       
        addressJTextField.setEnabled(true);
        cityJTextField.setEnabled(true);
        countyJComboBox.setEnabled(true);
        contactNumJTextField.setEnabled(true);
        descJTextField.setEnabled(true);
        contactNumJTextField.setEnabled(true);
        priceJTextField.setEnabled(true);
        jRadioBtnYes.setEnabled(true);
        jRadioBtnNo.setEnabled(true);      
    }
    
    private void lockFields()
    {      
        arrivalJTextField.setEnabled(false);
        parcelIDJTextField.setEnabled(false);
        nameJTextField.setEnabled(false);
        addressJTextField.setEnabled(false);
        cityJTextField.setEnabled(false);
        countyJComboBox.setEnabled(false);
        contactNumJTextField.setEnabled(false);
        descJTextField.setEnabled(false);
        contactNumJTextField.setEnabled(false);
        priceJTextField.setEnabled(false);
        jRadioBtnYes.setEnabled(false);
        jRadioBtnNo.setEnabled(false);      
    }
    
    private boolean checkIfNum(String num)
    {
        String regex = "\\d*\\.?\\d*";
        String data = priceJTextField.getText();
        
        if(!data.matches(regex))
        {
            return false;
        } 
        
        return true;
    }
    
    public static void main(String args[]) {


    
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton addJBtn;
    private javax.swing.JLabel addressJLabel;
    private javax.swing.JTextField addressJTextField;
    private javax.swing.JLabel arrivalJLabel;
    private javax.swing.JTextField arrivalJTextField;
    private javax.swing.JButton backJBtn;
    private javax.swing.ButtonGroup buttonGroup1;
    private javax.swing.JLabel cityJLabel;
    private javax.swing.JTextField cityJTextField;
    private javax.swing.JLabel contactNumJLabel;
    private javax.swing.JTextField contactNumJTextField;
    private javax.swing.JComboBox<String> countyJComboBox;
    private javax.swing.JLabel countyJLabel;
    private javax.swing.JLabel descJLabel;
    private javax.swing.JTextField descJTextField;
    private javax.swing.JButton displayAllJBtn;
    private javax.swing.JButton editJBtn;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JRadioButton jRadioBtnNo;
    private javax.swing.JRadioButton jRadioBtnYes;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JSeparator jSeparator1;
    private javax.swing.JSeparator jSeparator2;
    private javax.swing.JSeparator jSeparator3;
    private javax.swing.JSeparator jSeparator4;
    private javax.swing.JSeparator jSeparator5;
    private javax.swing.JLabel nameJLabel;
    private javax.swing.JTextField nameJTextField;
    private javax.swing.JButton nextJBtn;
    private javax.swing.JTextField parcelIDJTextField;
    private javax.swing.JLabel parcelIDJlabel;
    private javax.swing.JList<String> parcelJList;
    private javax.swing.JComboBox<String> parcelsByCountyJComboBox;
    private javax.swing.JLabel prepaidJLabel;
    private javax.swing.JLabel priceJLabel;
    private javax.swing.JTextField priceJTextField;
    private javax.swing.JButton removeJBtn;
    private javax.swing.JButton scanJBtn;
    private javax.swing.JLabel totalParcelsJLabel;
    private javax.swing.JTextField totalParcelsJTextField;
    private javax.swing.JButton updateJBtn;
    // End of variables declaration//GEN-END:variables
}
