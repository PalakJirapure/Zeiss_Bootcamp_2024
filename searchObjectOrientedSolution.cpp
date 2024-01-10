#include <iostream>
#include <vector>
#include <functional>

class StringFilter {
public:
    StringFilter(const std::vector<std::string>& strInputs) : strings(strInputs) {}

    std::vector<std::string> filter(std::function<bool(const std::string&)> predicateFn) {
        std::vector<std::string> result;
        for (const auto& item : strings) {
            if (predicateFn(item)) {
                result.push_back(item);
            }
        }
        return result;
    }

private:
    std::vector<std::string> strings;
};

class StringPrinter {
public:
    static void printToTerminal(const std::vector<std::string>& array) {
        for (const auto& item : array) {
            std::cout << item << std::endl;
        }
    }
};

class DifferentLetterFilter {
public:
    static std::function<bool(const std::string&)> checkStringStartsWithDifferentLetter(char startChar) {
        return [startChar](const std::string& stringItem) {
            return stringItem[0] == startChar; 
        };
    }
};

class StringFilterPrinter : public StringFilter, public StringPrinter {
public:
    using StringFilter::StringFilter;
    using StringPrinter::printToTerminal;
};

int main() {
    std::vector<std::string> strings = {"Hey", "World", "Amway", "Hi", "ab"};

    StringFilterPrinter filterPrinter(strings);
    
   
    auto filteredResult = filterPrinter.filter(DifferentLetterFilter::checkStringStartsWithDifferentLetter('W'));

    
    filterPrinter.printToTerminal(filteredResult);

    return 0;
}
