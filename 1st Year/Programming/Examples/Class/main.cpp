#include <iostream>
#include <string>

using namespace std;

class nameClass
{
    public:
        nameClass(string z)
        {
            name = z;
        }

        void setName(string x)
        {
            name = x;
        }

        string getName()
        {
            return name;
        }

    private:
        string name;

};

int main(){

    nameClass nameObject("Jiminy Cricket");
    cout << nameObject.getName() << endl;

    nameObject.setName() << endl;

}
