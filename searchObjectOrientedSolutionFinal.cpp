#include <iostream>
#include <vector>

using namespace std;

class StartsWithStrategy {
private:
    char startChar;

public:
    void setStartChar(char key) {
        startChar = key;
    }

    bool invokeStrategy(const string& stringItem) const {
        return stringItem[0] == startChar;
    }
};

class StringListFilterController {
private:
    StartsWithStrategy strategy;

public:
    vector<string> filter(const vector<string>& stringList) const {
        vector<string> result;
        for (const auto& stringItem : stringList) {
            if (strategy.invokeStrategy(stringItem)) {
                result.push_back(stringItem);
            }
        }
        return result;
    }

    void setStrategyStartChar(char key) {
        strategy.setStartChar(key);
    }
};

class ConsoleDisplayController {
private:
    string content;

public:
    void setContent(const vector<string>& messages) {
        for (const auto& message : messages) {
            content += message + "\n";
        }
    }

    void display() const {
        cout << content;
    }
};

int main() {
    vector<string> strings = {"Hey", "Work", "Happy", "Amway", "ab"};

    ConsoleDisplayController displayObject;
    StringListFilterController filterObject;

    filterObject.setStrategyStartChar('W');
    displayObject.setContent(filterObject.filter(strings));
    displayObject.display();

    return 0;
}
