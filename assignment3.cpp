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

    void printToTerminal(const std::vector<std::string>& array) {
        for (const auto& item : array) {
            std::cout << item << std::endl;
        }
    }

    static std::function<bool(const std::string&)> checkStringStartsWithAny(char startChar) {
        return [startChar](const std::string& stringItem) {
            return stringItem[0] == startChar;
        };
    }

private:
    std::vector<std::string> strings;
};

int main() {
    std::vector<std::string> strings = {"Hey", "World", "Am", "Hi", "ab"};
    
    StringFilter stringFilter(strings);
    auto filteredResult = stringFilter.filter(StringFilter::checkStringStartsWithAny('W'));
    stringFilter.printToTerminal(filteredResult);

    return 0;
}
