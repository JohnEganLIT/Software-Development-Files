#pragma once
class CPerson
{
public:
	CPerson();
	~CPerson();
	
	virtual void display();
	virtual void getUserInput();
protected:
	string m_name;
	string m_address;
	string m_city;
	string m_state;
	string m_zip;
};

