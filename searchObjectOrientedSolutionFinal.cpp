#include <iostream>
#include <vector>
#include <functional>

class Filter {
public:
    std::vector<std::string> result;
    std::function<bool(const std::string&)> predicateFn;

    Filter(std::function<bool(const std::string&)> predicate) : predicateFn(predicate) {}

    void filterInput(const std::vector<std::string>& inputStrings) {
        for (const auto& item : inputStrings) {
            if (predicateFn(item)) {
                result.push_back(item);
            }
        }
    }

    std::vector<std::string> getResult() const {
        return result;
    }
};

class IO {
public:
    void printArrayToTerminal(const std::vector<std::string>& array) {
        for (const auto& item : array) {
            std::cout << item << std::endl;
        }
    }
};

class Predicate {
public:
    static std::function<bool(const std::string&)> checkStringStartsWithAny(char startChar) {
        return [startChar](const std::string& stringItem) {
            return stringItem[0] == startChar;
        };
    }
};

int main() {
    std::vector<std::string> strings = {"Hey", "World", "Amway", "Heya", "a"};

    Predicate predicateObject;
    Filter filterObject(Predicate::checkStringStartsWithAny('A'));
    IO iObject;

    filterObject.filterInput(strings);
    auto filteredResult = filterObject.getResult();
    iObject.printArrayToTerminal(filteredResult);

    return 0;
}
