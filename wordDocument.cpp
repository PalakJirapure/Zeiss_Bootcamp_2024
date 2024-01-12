#include <iostream>
#include <vector>
#include <string>

using namespace std;

class DocumentPart;

class Visitor {
public:
    virtual void visitHeader(const class Header& header) = 0;
    virtual void visitParagraph(const class Paragraph& paragraph) = 0;
    virtual void visitHyperlink(const class Hyperlink& hyperlink) = 0;
    virtual void visitFooter(const class Footer& footer) = 0;
};

class DocumentPart {
public:
    string name;
    int position;

    DocumentPart(const string& n, int pos) : name(n), position(pos) {}

    virtual void accept(Visitor& visitor) const = 0;
};

class Header : public DocumentPart {
public:
    string title;

    Header(const string& n, int pos, const string& t) : DocumentPart(n, pos), title(t) {}

    void accept(Visitor& visitor) const override {
        visitor.visitHeader(*this);
    }
};

class Paragraph : public DocumentPart {
public:
    string content;
    int lines;

    Paragraph(const string& n, int pos, const string& c, int l) : DocumentPart(n, pos), content(c), lines(l) {}

    void accept(Visitor& visitor) const override {
        visitor.visitParagraph(*this);
    }
};

class Hyperlink : public DocumentPart {
public:
    string text;
    string url;

    Hyperlink(const string& n, int pos, const string& t, const string& u)
        : DocumentPart(n, pos), text(t), url(u) {}

    void accept(Visitor& visitor) const override {
        visitor.visitHyperlink(*this);
    }
};

class Footer : public DocumentPart {
public:
    string text;

    Footer(const string& n, int pos, const string& t) : DocumentPart(n, pos), text(t) {}

    void accept(Visitor& visitor) const override {
        visitor.visitFooter(*this);
    }
};

class HTMLConverter : public Visitor {
public:
    string result;

    void visitHeader(const Header& header) override {
        
    }

    void visitParagraph(const Paragraph& paragraph) override {
        
    }

    void visitHyperlink(const Hyperlink& hyperlink) override {
        
    }

    void visitFooter(const Footer& footer) override {
        
    }
};

int main() {
    
}
