// regex.cpp : Defines the entry point for the console application.
//

#include <iostream>
#include <regex>
#include <string>


int main(int argc, char *argv[])
{
	//system("PAUSE");
	if (argc != 3) {
		std::cerr << "Invalid number of arguments!";
		return -1;
	}

	try {
		std::regex reg(argv[1]);
		std::cmatch m;
		std::regex_match(argv[2], m, reg);

		if (m.size() == reg.mark_count() + 1) {
			std::cout << "Ok, all sub-expressions captured.\n";

			std::cout << "Matched expression: " << m[0] << "\n";
			for (unsigned i = 1; i<m.size(); ++i)
				std::cout << "Sub-expression " << i << ": " << m[i] << "\n";
		}
	}
	catch (std::regex_error regExec) {
		std::cerr << "Invalid regular expression!";
		return 1;
	}

	catch (std::exception e) {
		std::cout << "An unknown error occurred.";
	}

	

	return 0;
}
