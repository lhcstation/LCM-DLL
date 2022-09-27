
#include <stdio.h>
#include <lcm/lcm-cpp.hpp>
#include "example_t.hpp"

class Handler {
  public:
    ~Handler() {}
    void handleMessage(const lcm::ReceiveBuffer *rbuf, const std::string &chan,
                       const exlcm::example_t *msg)
    {
        int i;
        printf("\n");
        printf("  Time            = %f\n", msg->time);
        printf("  velID           = %d\n", msg->velID);
        printf("  velFrontcoor    = (%f, %f)\n", msg->velFrontcoorX, msg->velFrontcoorY);
        printf("  velEndcoor      = (%f, %f)\n", msg->velEndcoorX, msg->velEndcoorX);
        printf("  ====================================  \n");
    }
};

int main(int argc, char **argv)
{
    lcm::LCM lcm;

    if (!lcm.good())
        return 1;

    Handler handlerObject;
    lcm.subscribe("EXAMPLE", &Handler::handleMessage, &handlerObject);

    while (0 == lcm.handle()) {
        // Do nothing
    }

    return 0;
}