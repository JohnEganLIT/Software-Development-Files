#pragma once
class Animal
{
	public:
		Animal(string, int, float);
		~Animal();

		string getName();
		int getAge();
		float getWeight();

	protected:
		string name;
		int age;
		float weight;
};

