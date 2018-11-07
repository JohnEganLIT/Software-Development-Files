#include <iostream>
#include <string>

using namespace std;

class nameClass
{
    public:
        void setName(string x){
            name = x;
        }
        string getName()
        {
            return name;
        }

    private:
        string name;
};

int main()
{
    nameClass nameObject;
    nameObject.setName("Colin Maher");

    cout << nameObject.getName();
}
