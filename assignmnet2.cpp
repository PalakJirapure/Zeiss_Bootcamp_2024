#include <iostream>
#include <vector>
#include <functional>


std::vector<std::string> filter(const std::vector<std::string>& str_inputs, std::function<bool(const std::string&)> predicateFn) {
    std::vector<std::string> result;
    for (const auto& item : str_inputs) {
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


std::function<bool(const std::string&)> checkStringStartsWithAny(char start_char) {
    return [start_char](const std::string& string_item) {
        return string_item[0] == start_char;
    };
}

int main() {
  
    std::vector<std::string> strings = {"Hey", "World", "Am", "Hi", "ab"};
    auto filtered_result = filter(strings, checkStringStartsWithAny('W'));
    printToTerminal(filtered_result);

    return 0;
}
